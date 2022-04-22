using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Rookie.AssetManagement.Authorize;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Controller;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.IntegrationTests.Common;
using Rookie.AssetManagement.IntegrationTests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.IntegrationTests
{
    public class AuthControllerShould : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly AuthorizeController _authorizeController;
        private readonly IAuthManager _authManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AuthControllerShould(SqliteInMemoryFixture fixture)
        {
            fixture.CreateDatabase();
            _dbContext = fixture.Context;
            _userManager = fixture.UserManager;
            _signInManager = fixture.SignInManager;
            _signInManager.Context = new DefaultHttpContext { RequestServices = fixture.ServiceProvider };
            _roleManager = fixture.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();
            _authManager = new AuthManager(_userManager,_signInManager);
            _authorizeController = new AuthorizeController(_userManager, _authManager, _mapper);
            AuthArrangeData.InitUsersData(_dbContext,_userManager,_roleManager);
        }

        [Fact]
        public  async void Login_ValidInfo_ReturnUserInfoAndToken()
        {
            //arrange
            UserLoginDTO dto = new UserLoginDTO()
            {
                UserName = "adminhcm",
                Password = "123456"
            };
            //act

            var result = await _authorizeController.Login(dto);

            //assert

            Assert.NotNull(result);
            Assert.IsType<UserLoginResponseDTO>(result);
            Assert.Equal("adminhcm",result.UserName);
            Assert.Equal("SD0001",result.StaffCode);
            Assert.NotNull(result.Token);

           
        }
        [Fact]
        public async void Login_InvalidInfo_ReturnErrorAndMessage()
        {
            //arrange
            UserLoginDTO dto = new UserLoginDTO()
            {
                UserName = "adminhcm",
                Password = "123sss456"
            };
            //act

            var result = await _authorizeController.Login(dto);

            //assert

            Assert.NotNull(result);
            Assert.IsType<UserLoginResponseDTO>(result);
            Assert.True(result.Error);
            Assert.Equal("Username or password is incorrect. Please try again",result.Message);

        }
        [Fact]
        public async void Me_ValidToken_ReturnUserInfo()
        {
            //arrange
            var _user = AuthArrangeData.ValidUser();
            var claims = new List<Claim>()
            {
                new Claim(UserClaims.StaffCode,_user.StaffCode),
                new Claim(UserClaims.UserName,_user.UserName),
                new Claim(UserClaims.Location,_user.Location.ToString()),
                new Claim(UserClaims.Id,_user.Id.ToString()),
                new Claim(UserClaims.Role,"ADMIN"),
                new Claim(UserClaims.FullName,_user.GetFullName()),
                new Claim(UserClaims.FirstLogin,_user.FirstLogin.ToString()),
                new Claim(UserClaims.IsDisable,_user.IsDisable.ToString()),
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext()
            {
                User = claimsPrincipal
            };

            //Controller needs a controller context to access HttpContext
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };
            _authorizeController.ControllerContext= controllerContext;
            //act

            var result = await _authorizeController.Me();

            //assert

            Assert.NotNull(result);
            Assert.IsType<UserLoginResponseDTO>(result);
            Assert.Equal("adminhcm",result.UserName);
            Assert.Equal("SD0001",result.StaffCode);
        }

        [Fact]
        public async void ChangePassword_InValidInput_ReturnError()
        {
            //arrange
            var _user = AuthArrangeData.ValidUser();
            var claims = new List<Claim>()
            {
                new Claim(UserClaims.StaffCode,_user.StaffCode),
                new Claim(UserClaims.UserName,_user.UserName),
                new Claim(UserClaims.Location,_user.Location.ToString()),
                new Claim(UserClaims.Id,_user.Id.ToString()),
                new Claim(UserClaims.Role,"ADMIN"),
                new Claim(UserClaims.FullName,_user.GetFullName()),
                new Claim(UserClaims.FirstLogin,_user.FirstLogin.ToString()),
                new Claim(UserClaims.IsDisable,_user.IsDisable.ToString()),
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext()
            {
                User = claimsPrincipal
            };

            //Controller needs a controller context to access HttpContext
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };
            _authorizeController.ControllerContext = controllerContext;

            var dto = new UserChangePasswordDTO()
            {
                CurrentPassword = "123456sss",
                NewPassword = "123456789"
            };

            //act

            var result = await _authorizeController.ChangePassword(dto);
            //assert

            Assert.NotNull(result);
            Assert.IsType<UserLoginResponseDTO>(result);
            Assert.True(result.Error);
            Assert.Equal("Password is incorrect. Please try again", result.Message);

        }
    }
}
