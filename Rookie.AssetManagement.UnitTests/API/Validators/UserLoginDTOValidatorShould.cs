using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Tests.Validations;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using Rookie.AssetManagement.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.API.Validators
{
    public class UserLoginDTOValidatorShould : BaseValidatorShould
    {
        private readonly ValidationTestRunner<UserLoginDTOValidator, UserLoginDTO> _testRunner;

        public UserLoginDTOValidatorShould()
        {
            _testRunner = ValidationTestRunner
                .Create<UserLoginDTOValidator, UserLoginDTO>(new UserLoginDTOValidator());
        }

        [Theory]
        [MemberData(nameof(AuthorizeTestData.InvalidUserLoginDTOWithNoUsernameAndPassword), MemberType = typeof(AuthorizeTestData))]
        public void HaveErrorWhenLoginDTOIsinvalid(string userName, string password, string errorMessage, string errorMessage2)
        {
            _testRunner
                .For(m => m.UserName = userName)
                .ShouldHaveErrorsFor(m => m.UserName, errorMessage);
            _testRunner
                .For(m => m.Password = password)
                .ShouldHaveErrorsFor(m => m.Password, errorMessage2);
        }

        [Theory]
        [MemberData(nameof(AuthorizeTestData.InvalidUserLoginDTOWithNoPassword), MemberType = typeof(AuthorizeTestData))]
        public void HaveErrorWhenLoginDTOIsinvalid2(string userName, string password, string errorMessage)
        {
            _testRunner
                 .For(m => m.UserName = userName)
                 .ShouldNotHaveErrorsFor(m => m.UserName);
            _testRunner
                .For(m => m.Password = password)
                .ShouldHaveErrorsFor(m => m.Password, errorMessage);
        }
        [Theory]
        [MemberData(nameof(AuthorizeTestData.InvalidUserLoginDTOWithNoUsername), MemberType = typeof(AuthorizeTestData))]
        public void HaveErrorWhenLoginDTOIsinvalid3(string userName, string password, string errorMessage)
        {
            _testRunner
                .For(m => m.Password = password)
                .ShouldNotHaveErrorsFor(m => m.Password);
            _testRunner
                .For(m => m.UserName = userName)
                .ShouldHaveErrorsFor(m => m.UserName, errorMessage);

        }

        [Theory]
        [MemberData(nameof(AuthorizeTestData.ValidUserLoginDTO), MemberType = typeof(AuthorizeTestData))]
        public void HaveNoErrorWhenLoginDTOIsvalid(string userName, string password)
        {
            _testRunner
                .For(m => m.Password = password)
                .ShouldNotHaveErrorsFor(m => m.Password);
            _testRunner
                .For(m => m.UserName = userName)
                .ShouldNotHaveErrorsFor(m => m.UserName);

        }
    }
}
