using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EnsureThat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IHttpContextAccessor _httpcontext;
        public UserService(IBaseRepository<User> userRepository,
            IMapper mapper,
            IHttpContextAccessor httpcontext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpcontext = httpcontext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<PagedResponseModel<UserDto>> GetByPageAsync(
            UserQueryCriteriaDto userQueryCriteria,
            CancellationToken cancellationToken,
            int userid)
        {
            var location = _userRepository.Entities
                .Where(x => x.Id == userid)
                .Select(x => x.Location)
                .FirstOrDefault();

            var userQuery = UserFilter(
                _userRepository.Entities.AsQueryable(),
                userQueryCriteria);

            var users = await userQuery
                .AsNoTracking()
                .Where(x => x.Location == location)
                .PaginateAsync(
                    userQueryCriteria,
                    cancellationToken);

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users.Items);

            return new PagedResponseModel<UserDto>
            {
                CurrentPage = users.CurrentPage,
                TotalPages = users.TotalPages,
                TotalItems = users.TotalItems,
                Items = usersDto
            };
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);

                return userDto;
            }
            return null;
        }

        public async Task<UserDto> RegisterUser(UserCreateDto userCreateRequest)
        {
            Ensure.Any.IsNotNull(userCreateRequest);

            var claims = _httpcontext.HttpContext.User.Claims.ToList();
            Dictionary<string, string> claimsDictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsDictionary.Add(claim.Type, claim.Value);
            }

            var userName = GenerateUserNameExtension.GenerateUserName(userCreateRequest.FirstName, userCreateRequest.LastName, _userManager);
            //var password = GeneratePasswordExtension.GeneratePassword(userName, userCreateRequest.DOB);
            var password = "123456";
            var staffCode = GenerateStaffCodeExtension.GenerateStaffCode(_userManager);

            var newUser = _mapper.Map<User>(userCreateRequest);
            newUser.UserName = userName;
            newUser.StaffCode = staffCode;
            newUser.Location = (UserLocationEnum)Enum.Parse(typeof(UserLocationEnum), claimsDictionary[UserClaims.Location]);
            newUser.FirstLogin = true;

            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, userCreateRequest.Type == UserTypeEnum.Admin ? Roles.Admin : Roles.Staff);
                return _mapper.Map<UserDto>(newUser);
            }
            return null;

        }
        
        public async Task<UserDto> UpdateAsync(int id, UserCreateDto userRequest)
        {
            var user = await _userRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new NotFoundException("Not Found!");
            }

            user.DOB = userRequest.DOB;
            user.Type = userRequest.Type;
            user.Gender = userRequest.Gender;
            user.JoinDate = userRequest.JoinDate;

            var userUpdated = await _userRepository.Update(user);

            var userUpdatedDto = _mapper.Map<UserDto>(userUpdated);

            return userUpdatedDto;
        }

        #region Private Method
        private IQueryable<User> UserFilter(
            IQueryable<User> userQuery,
            UserQueryCriteriaDto userQueryCriteria)
        {
            if (!String.IsNullOrEmpty(userQueryCriteria.Search))
            {
                userQuery = userQuery.Where(b =>
                    b.FullName.Contains(userQueryCriteria.Search) || b.StaffCode.Contains(userQueryCriteria.Search));
            }

            if (userQueryCriteria.Types != null &&
                userQueryCriteria.Types.Count() > 0 &&
               !userQueryCriteria.Types.Any(x => x == (int)UserTypeEnumDto.All))
            {
                userQuery = userQuery.Where(x =>
                    userQueryCriteria.Types.Any(t => t == (int)x.Type));
            }

            return userQuery;
        }

        #endregion


    }
}
