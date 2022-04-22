using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using Rookie.AssetManagement.Authorize;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.Business
{
    public class AuthManagerShould
    {
        private readonly AuthManager _authManager;
        private readonly Mock<UserManager<User>> _userManager;
        private readonly Mock<SignInManager<User>> _signInManager;
        public AuthManagerShould()
        {

            _userManager = new Mock<UserManager<User>>(
                /* IUserStore<TUser> store */Mock.Of<IUserStore<User>>(),
                /* IOptions<IdentityOptions> optionsAccessor */null,
                /* IPasswordHasher<TUser> passwordHasher */null,
                /* IEnumerable<IUserValidator<TUser>> userValidators */null,
                /* IEnumerable<IPasswordValidator<TUser>> passwordValidators */null,
                /* ILookupNormalizer keyNormalizer */null,
                /* IdentityErrorDescriber errors */null,
                /* IServiceProvider services */null,
                /* ILogger<UserManager<TUser>> logger */null);
            _signInManager = new Mock<SignInManager<User>>(
                _userManager.Object,
                /* IHttpContextAccessor contextAccessor */Mock.Of<IHttpContextAccessor>(),
                /* IUserClaimsPrincipalFactory<TUser> claimsFactory */Mock.Of<IUserClaimsPrincipalFactory<User>>(),
                /* IOptions<IdentityOptions> optionsAccessor */null,
                /* ILogger<SignInManager<TUser>> logger */null,
                /* IAuthenticationSchemeProvider schemes */null,
                /* IUserConfirmation<TUser> confirmation */null);
            _authManager = new AuthManager(_userManager.Object, _signInManager.Object);
        }


        [Fact]
        public async void ValidateUser_LoginSuccess_ReturnTrue()
        {
            //Arrange
            var user = AuthorizeTestData.GetUser();
            var loginDTO = AuthorizeTestData.GetValidUsersLoginDTO();

            _userManager.Setup(um => um.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(user);
            _signInManager.Setup(sm => sm.PasswordSignInAsync(
                It.IsAny<string>(),
                It.IsAny<string>(), 
                It.IsAny<bool>(),
                It.IsAny<bool>())).
            ReturnsAsync(SignInResult.Success);

            //Act

            var result = await _authManager.ValidateUser(loginDTO);

            //Assert
            Assert.True(result);

        }

        [Fact]
        public async void ValidateUser_LoginFailed_ReturnFalse()
        {
            //Arrange
            var user = AuthorizeTestData.GetUser();
            var loginDTO = AuthorizeTestData.GetValidUsersLoginDTO();

            _userManager.Setup(um => um.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(user);
            _signInManager.Setup(sm => sm.PasswordSignInAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>(),
                It.IsAny<bool>())).
            ReturnsAsync(SignInResult.Failed);

            //Act

            var result = await _authManager.ValidateUser(loginDTO);

            //Assert

            Assert.True(!result);

        }

        [Fact]
        public async void CreateToken_ValidLogin_ReturnToken()
        {
            //Arrange
            var user = AuthorizeTestData.GetUser();
            var loginDTO = AuthorizeTestData.GetValidUsersLoginDTO();

            _userManager.Setup(um => um.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManager.Setup(um => um.GetRolesAsync(user)).ReturnsAsync(new List<string> { "ADMIN" });
            _signInManager.Setup(sm => sm.PasswordSignInAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>(),
                It.IsAny<bool>())).
            ReturnsAsync(SignInResult.Success);

            //Act

            var resultLogin = await _authManager.ValidateUser(loginDTO);
            var token = await _authManager.CreateToken();

            //Assert
            Assert.True(resultLogin);
            Assert.NotNull(token);

        }
    }
}
