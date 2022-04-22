using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.IntegrationTests.Common;
using Rookie.AssetManagement.IntegrationTests.TestData;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Rookie.AssetManagement.Authorize;
using Rookie.AssetManagement.Controller;
using Xunit;
using Rookie.AssetManagement.Business.Services;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Tests;
using System.Threading.Tasks;
using Rookie.AssetManagement.DataAccessor.Enums;
using System.Threading;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;

namespace Rookie.AssetManagement.IntegrationTests
{
    public class UserControllerShould : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly BaseRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly UsersController _userController;
        private readonly IAuthManager _authManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserService _userService;
        private readonly HttpContextAccessor _httpContext;

        public UserControllerShould(SqliteInMemoryFixture fixture)
        {
            fixture.CreateDatabase();
            _dbContext = fixture.Context;
            _userManager = fixture.UserManager;
            _signInManager = fixture.SignInManager;
            _signInManager.Context = new DefaultHttpContext { RequestServices = fixture.ServiceProvider };
            _roleManager = fixture.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            _userRepository=new BaseRepository<User>(_dbContext);
            _httpContext=new HttpContextAccessor();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();
            _authManager = new AuthManager(_userManager,_signInManager);
            _userService = new UserService(_userRepository,_mapper,_httpContext,_userManager,_signInManager,_roleManager);
            _userController = new UsersController(_userService);
            UserArrangeData.InitUsersData(_dbContext,_roleManager);
            AddClaims();
        }
        public void AddClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(UserClaims.Id,1.ToString()),
                new Claim(UserClaims.Role,Roles.Admin),
                new Claim(UserClaims.Location,UserLocationEnum.HCM.ToString()),
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext()
            {
                User = claimsPrincipal
            };
            _httpContext.HttpContext = httpContext;

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };
            _userController.ControllerContext = controllerContext;
        }

        [Fact]
        public async Task GetUsers_Success()
        {
            //Arrange
            var UserQueryCriteriaDto = UserArrangeData.GetUserQueryCriteriaDto();

            // Act
            var result = await _userController.GetUsers(UserQueryCriteriaDto, new CancellationToken());
            // Assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<PagedResponseModel<UserDto>>(actionResult.Value);
            Assert.Equal(4, returnValue.TotalItems);
        }
        [Fact]
        public async Task RegisterUser_ReturnsStatusCode200Ok_WhenValidUser() {
            // Arrange
            var userCreateRequest = UserArrangeData.GetCreateNewUserDto();
            
            //Act
            var actual = (OkObjectResult)await _userController.Create(userCreateRequest);
        
            //Assert
            actual.Should().NotBeNull();
            actual.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task RegisterUser_ReturnsStatusCode400BadRequest_WhenInValidUser() {
            //Arrange          
            var userCreateRequest = UserArrangeData.GetInValidCreateNewUserDto();
            
            //Act
            var actual = (BadRequestObjectResult)await _userController.Create(userCreateRequest);

            //Assert
            actual.Should().NotBeNull();
            actual.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task UpdateUser_ReturnsStatusCode200Ok_WhenValidUser()
        {
            // Arrange
            var existedid = 1;
            var userEditRequest = UserArrangeData.GetCreateNewUserDto();

            //Act
            var actual = await _userController.UpdateUser(existedid, userEditRequest);

            //Assert
            actual.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            actual.Should().NotBeNull();

            var actionResult = Assert.IsType<OkObjectResult>(actual.Result);
            var returnValue = Assert.IsType<UserDto>(actionResult.Value);

            returnValue.DOB.Equals(userEditRequest.DOB);
            returnValue.JoinDate.Equals(userEditRequest.JoinDate);
            returnValue.Gender.Equals(userEditRequest.Gender);
            returnValue.Type.Equals(userEditRequest.Type);
        }

        [Fact]
        public async Task UpdateUser_ReturnsStatusCode400BadRequest_WhenInValidUser()
        {
            // Arrange
            var existedid = 1;
            var userEditRequest = UserArrangeData.GetInValidCreateNewUserDto();

            //Act
            var actual = await _userController.UpdateUser(existedid, userEditRequest);

            //Assert
            actual.Result.Should().HaveStatusCode(StatusCodes.Status400BadRequest);
            var actionResult = Assert.IsType<BadRequestObjectResult>(actual.Result);
            actionResult.Value.Should().NotBeNull();
        }
    }
}
