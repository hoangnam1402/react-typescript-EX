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
    public class UserChangePasswordDTOValidatorShould
    {
        private readonly ValidationTestRunner<UserChangePasswordValidator, UserChangePasswordDTO> _testRunner;

        public UserChangePasswordDTOValidatorShould()
        {
            _testRunner = ValidationTestRunner
                .Create<UserChangePasswordValidator, UserChangePasswordDTO>(new UserChangePasswordValidator());
        }

        [Theory]
        [MemberData(nameof(AuthorizeTestData.InvalidUserChangePasswordDTO), MemberType = typeof(AuthorizeTestData))]
        public void HaveErrorWhenChangePasswordDTOIsinvalid(string currentPassword, string newPassword, string errorMessage, string errorMessage2)
        {
            _testRunner
                .For(m => m.CurrentPassword = currentPassword)
                .ShouldHaveErrorsFor(m => m.CurrentPassword, errorMessage);
            _testRunner
                .For(m => m.NewPassword = newPassword)
                .ShouldHaveErrorsFor(m => m.NewPassword, errorMessage2);
        }


        [Theory]
        [MemberData(nameof(AuthorizeTestData.InvalidUserChangePasswordDTONoCurrentPassword), MemberType = typeof(AuthorizeTestData))]
        public void HaveErrorWhenChangePasswordDTOIsinvalid2(string currentPassword, string newPassword, string errorMessage)
        {
            _testRunner
                .For(m => m.CurrentPassword = currentPassword)
                .ShouldHaveErrorsFor(m => m.CurrentPassword, errorMessage);
            _testRunner
                .For(m => m.NewPassword = newPassword)
                .ShouldNotHaveErrorsFor(m => m.NewPassword);
        }

        [Theory]
        [MemberData(nameof(AuthorizeTestData.InvalidUserChangePasswordDTONoNewPassword), MemberType = typeof(AuthorizeTestData))]
        public void HaveErrorWhenChangePasswordDTOIsinvalid3(string currentPassword, string newPassword, string errorMessage)
        {
            _testRunner
                .For(m => m.NewPassword = newPassword)
                .ShouldHaveErrorsFor(m => m.NewPassword, errorMessage);
            _testRunner
                .For(m => m.CurrentPassword = currentPassword)
                .ShouldNotHaveErrorsFor(m => m.CurrentPassword);
        }

        [Theory]
        [MemberData(nameof(AuthorizeTestData.ValidUserChangePasswordDTO), MemberType = typeof(AuthorizeTestData))]
        public void HaveNoErrorWhenChangePasswordDTOIsValid(string currentPassword, string newPassword)
        {
            _testRunner
                .For(m => m.NewPassword = newPassword)
                .ShouldNotHaveErrorsFor(m => m.NewPassword);
            _testRunner
                .For(m => m.CurrentPassword = currentPassword)
                .ShouldNotHaveErrorsFor(m => m.CurrentPassword);
        }
    }
}
