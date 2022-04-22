using FluentAssertions;
using FluentValidation.Results;
using Moq;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Tests.Validations;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using Rookie.AssetManagement.Validators;
using System;
using System.Threading.Tasks;
using Xunit;
using Rookie.AssetManagement.DataAccessor.Enums;


namespace Rookie.AssetManagement.UnitTests.API.Validators
{
    public class UserDtoValidatoreShould : BaseValidatorShould
    {
        private readonly ValidationTestRunner<UserDtoValidator, UserCreateDto> _testRunner;

        public UserDtoValidatoreShould()
        {
            _testRunner = ValidationTestRunner
                .Create<UserDtoValidator, UserCreateDto>(new UserDtoValidator());
        }

        [Theory]
        [MemberData(nameof(UserTestsData.ValidLastNames), MemberType = typeof(UserTestsData))]
        public void NotHaveErrorWhenLastNameIsValid(string lastName) =>
            _testRunner
                .For(m => m.LastName = lastName)
                .ShouldNotHaveErrorsFor(m => m.LastName);
        [Theory]
        [MemberData(nameof(UserTestsData.IsNullLastNames), MemberType = typeof(UserTestsData))]
        public void HaveErrorWhenLastNameIsNull(string lastName, string errorMessage) =>
            _testRunner
                .For(m => m.LastName = lastName)
                .ShouldHaveErrorsFor(m => m.LastName,errorMessage);
        [Theory]
        [MemberData(nameof(UserTestsData.IsInValidLastName), MemberType = typeof(UserTestsData))]
        public void HaveErrorWhenLastNameHaveSpecialCharacter(string lastName, string errorMessage) =>
            _testRunner
                .For(m => m.LastName = lastName)
                .ShouldHaveErrorsFor(m => m.LastName,errorMessage);
        [Theory]
        [MemberData(nameof(UserTestsData.IsEmptyLastName), MemberType = typeof(UserTestsData))]
        public void HaveErrorWhenLastNameIsEmpty(string lastName, string errorMessage) =>
            _testRunner
                .For(m => m.LastName = lastName)
                .ShouldHaveErrorsFor(m => m.LastName,errorMessage);

        [Theory]
        [MemberData(nameof(UserTestsData.ValidFirstNames), MemberType = typeof(UserTestsData))]
        public void NotHaveErrorWhenIdsFirstNamevalid(string firstName) =>
            _testRunner
                .For(m => m.FirstName = firstName)
                .ShouldNotHaveErrorsFor(m => m.FirstName);
        [Theory]
        [MemberData(nameof(UserTestsData.InValidFirstNames), MemberType = typeof(UserTestsData))]
        public void HaveErrorWhenFirstNameHaveSpecialCharacter(string firstName, string errorMessage) =>
            _testRunner
                .For(m => m.FirstName = firstName)
                .ShouldHaveErrorsFor(m => m.FirstName,errorMessage);
        [Theory]
        [MemberData(nameof(UserTestsData.IsNullFirstNames), MemberType = typeof(UserTestsData))]
        public void HaveErrorWhenFirstNameIsNull(string firstName, string errorMessage) =>
            _testRunner
                .For(m => m.FirstName = firstName)
                .ShouldHaveErrorsFor(m => m.FirstName,errorMessage);
        [Theory]
        [MemberData(nameof(UserTestsData.IsEmptyFirstNames), MemberType = typeof(UserTestsData))]
        public void HaveErrorWhenFirstNameIsEmpty(string firstName, string errorMessage) =>
            _testRunner
                .For(m => m.FirstName = firstName)
                .ShouldHaveErrorsFor(m => m.FirstName,errorMessage);
        [Theory]
        [MemberData(nameof(UserTestsData.ValidGender), MemberType = typeof(UserTestsData))]
        public void NotHaveErrorWhenGenderIsValid(UserGenderEnum gender) =>
            _testRunner
                .For(m => m.Gender = gender)
                .ShouldNotHaveErrorsFor(m => m.Gender);
        [Theory]
        [MemberData(nameof(UserTestsData.ValidType), MemberType = typeof(UserTestsData))]
        public void NotHaveErrorWhenTypeIsValid(UserTypeEnum type) =>
            _testRunner
                .For(m => m.Type = type)
                .ShouldNotHaveErrorsFor(m => m.Type);
        [Theory]
        [MemberData(nameof(UserTestsData.ValidDOB), MemberType = typeof(UserTestsData))]
        public void NotHaveErrorWhenDOBValid(DateTime dob) =>
            _testRunner
                .For(m => m.DOB = dob)
                .ShouldNotHaveErrorsFor(m => m.DOB);

        [Theory]
        [MemberData(nameof(UserTestsData.InvalidDOB), MemberType = typeof(UserTestsData))]
        public void HaveErrorWhenDOBInValid(DateTime dob, string errorMessage) =>
            _testRunner
                .For(m => m.DOB = dob)
                .ShouldHaveErrorsFor(m => m.DOB,errorMessage);
        [Theory]
        [MemberData(nameof(UserTestsData.ValidJoinDate), MemberType = typeof(UserTestsData))]
        public void NotHaveErrorWhenJoinDateValid(DateTime dob,DateTime joinDate) =>
            _testRunner
                .For(m => m.JoinDate = joinDate)
                .ShouldNotHaveErrorsFor(m => m.JoinDate);
        [Theory]
        [MemberData(nameof(UserTestsData.JoinDateIsSundayOrSaturday), MemberType = typeof(UserTestsData))]
        public void HaveErrorWhenJoinDateIsSaturdayOrSunday(DateTime joinDate, string errorMessage) =>
            _testRunner
                .For(m => m.JoinDate = joinDate)
                .ShouldHaveErrorsFor(m => m.JoinDate.Date.DayOfWeek,errorMessage); 
    }
}
