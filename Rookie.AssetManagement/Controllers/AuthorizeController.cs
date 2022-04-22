using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Rookie.AssetManagement.Authorize;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthManager _authManager;
        private readonly IMapper _mapper;

        public AuthorizeController(UserManager<User> userManager, IAuthManager authManager, IMapper mapper)
        {
            _userManager = userManager;
            _authManager = authManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<UserLoginResponseDTO> Login([FromBody]UserLoginDTO dto)
        {
            var validationResult = new UserLoginDTOValidator().Validate(dto);
            if (!validationResult.IsValid)
            {
                var error = "Username and password is required.";
                return new UserLoginResponseDTO
                {
                    Error = true,
                    Message = error,
                };
            }
            if (!await _authManager.ValidateUser(dto))
            {
                var error = "Username or password is incorrect. Please try again";
                return new UserLoginResponseDTO
                {
                    Error = true,
                    Message = error,
                };
            }
            User u = await _userManager.FindByNameAsync(dto.UserName);
            bool me = u.UserName == dto.UserName;
            //case sensitive request by qc
            if (!me)
            {
                var error = "Username or password is incorrect. Please try again";
                return new UserLoginResponseDTO
                {
                    Error = true,
                    Message = error,
                };
            }
            var roles = await _userManager.GetRolesAsync(u);
            var token = await _authManager.CreateToken();

            UserLoginResponseDTO result = new UserLoginResponseDTO()
            {
                Id = u.Id,
                FullName = u.GetFullName(),
                IsConfirmed = u.EmailConfirmed,
                Location = u.Location,
                Role = roles[0],
                StaffCode = u.StaffCode,
                Token = token,
                UserName = u.UserName,
                FirstLogin = u.FirstLogin,
                IsDisable = u.IsDisable,
                Error = false,
                Message = "",
            };
            return result;

        }

        [HttpGet("me")]
        [Authorize(Roles = "STAFF,ADMIN")]
        public async Task<UserLoginResponseDTO> Me()
        {
            var claims = User.Claims.ToList();
            Dictionary<string, string> claimsDictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsDictionary.Add(claim.Type, claim.Value);
            }

            var username = claimsDictionary[UserClaims.UserName];
            var user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user);

            UserLoginResponseDTO result = new UserLoginResponseDTO()
            {
                Id = user.Id,
                FullName = user.GetFullName(),
                IsConfirmed = user.EmailConfirmed,
                Location =  user.Location,
                Role = roles[0],
                StaffCode = user.StaffCode,
                Token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", ""),
                UserName = user.UserName,
                FirstLogin = user.FirstLogin,
                IsDisable = user.IsDisable,
                Error = false,
                Message = "",
            };

            return result;
        }

        [HttpPut]
        [Authorize(Roles = "STAFF,ADMIN")]
        public async Task<UserLoginResponseDTO> ChangePassword([FromBody] UserChangePasswordDTO dto)
        {
            var claims = User.Claims.ToList();
            Dictionary<string, string> claimsDictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsDictionary.Add(claim.Type, claim.Value);
            }
            var username = claimsDictionary[UserClaims.UserName];
            var user = await _userManager.FindByNameAsync(username);
            if (!await _authManager.ValidateUser(new UserLoginDTO { 
                    UserName=username,
                    Password=dto.CurrentPassword
                }
            ))
            {
                var error = "Password is incorrect. Please try again";
                return new UserLoginResponseDTO
                {
                    Error = true,
                    Message = error,
                };
            }
            //fix same password issue
            var samePassword = await _userManager.CheckPasswordAsync(user, dto.NewPassword);
            if (samePassword)
            {
                var error = "The new password cannot be the same as the old password";
                return new UserLoginResponseDTO
                {
                    Error = true,
                    Message = error,
                };
            }

            var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var changePassword = await _userManager.ResetPasswordAsync(user, passwordToken, dto.NewPassword);

            if (changePassword.Succeeded)
            {
                user.FirstLogin = false;
                await _userManager.UpdateAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                UserLoginResponseDTO result = new UserLoginResponseDTO()
                {
                    Id = user.Id,
                    FullName = user.GetFullName(),
                    IsConfirmed = user.EmailConfirmed,
                    Location = user.Location,
                    Role = roles[0],
                    StaffCode = user.StaffCode,
                    Token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", ""),
                    UserName = user.UserName,
                    FirstLogin = user.FirstLogin,
                    IsDisable = user.IsDisable,
                    Error = false,
                    Message = "",
                };

                return result;
            }
            else
            {
                var error = "Failed to change user password";
                return new UserLoginResponseDTO
                {
                    Error = true,
                    Message = error,
                };
            }
        }
    }
}
