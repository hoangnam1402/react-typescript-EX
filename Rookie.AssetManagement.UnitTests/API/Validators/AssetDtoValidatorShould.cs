using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.Tests.Validations;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using Rookie.AssetManagement.Validators;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.API.Validators
{
    public class AssetDtoValidatorShould : BaseValidatorShould
    {
        private readonly ValidationTestRunner<AssetDtoValidator, AssetCreateDTO> _testRunner;

        public AssetDtoValidatorShould()
        {
            _testRunner = ValidationTestRunner
              .Create<AssetDtoValidator, AssetCreateDTO>(new AssetDtoValidator());
        }

        [Theory]
        [MemberData(nameof(AssetTestData.ValidName), MemberType = typeof(AssetTestData))]
        public void NotHaveErrorWhenNameIsvalid(string name) =>
           _testRunner
               .For(m => m.Name = name)
               .ShouldNotHaveErrorsFor(m => m.Name);

        [Theory]
        [MemberData(nameof(AssetTestData.IsNullName), MemberType = typeof(AssetTestData))]
        public void HaveErrorWhenNameIsNull(string name, string errorMessage) =>
            _testRunner
                .For(m => m.Name = name)
                .ShouldHaveErrorsFor(m => m.Name, errorMessage);

        [Theory]
        [MemberData(nameof(AssetTestData.IsEmptyName), MemberType = typeof(AssetTestData))]
        public void HaveErrorWhenNameIsEmpty(string name, string errorMessage) =>
            _testRunner
                .For(m => m.Name = name)
                .ShouldHaveErrorsFor(m => m.Name, errorMessage);

        [Theory]
        [MemberData(nameof(AssetTestData.ValidSpecification), MemberType = typeof(AssetTestData))]
        public void NotHaveErrorWhenSpecificationIsvalid(string specification) =>
            _testRunner
                .For(m => m.Specification = specification)
                .ShouldNotHaveErrorsFor(m => m.Specification);

        [Theory]
        [MemberData(nameof(AssetTestData.IsNullSpecification), MemberType = typeof(AssetTestData))]
        public void HaveErrorWhenSpecificationIsNull(string specification, string errorMessage) =>
            _testRunner
                .For(m => m.Specification = specification)
                .ShouldHaveErrorsFor(m => m.Specification, errorMessage);

        [Theory]
        [MemberData(nameof(AssetTestData.IsEmptySpecification), MemberType = typeof(AssetTestData))]
        public void HaveErrorWhenSpecificationIsEmpty(string specification, string errorMessage) =>
            _testRunner
                .For(m => m.Specification = specification)
                .ShouldHaveErrorsFor(m => m.Specification, errorMessage);

        [Theory]
        [MemberData(nameof(AssetTestData.ValidInstallDate), MemberType = typeof(AssetTestData))]
        public void NotHaveErrorWhenInstallDateIsValid(DateTime installDate) =>
            _testRunner
                .For(m => m.InstallDate = installDate)
                .ShouldNotHaveErrorsFor(m => m.InstallDate);

        [Theory]
        [MemberData(nameof(AssetTestData.ValidState), MemberType = typeof(AssetTestData))]
        public void NotHaveErrorWhenStateIsValid(AssetStateEnum state) =>
            _testRunner
                .For(m => m.State = state)
                .ShouldNotHaveErrorsFor(m => m.State);

        [Theory]
        [MemberData(nameof(AssetTestData.ValidCategoryID), MemberType = typeof(AssetTestData))]
        public void NotHaveErrorWhenCategoryIDIsValid(int categoryID) =>
            _testRunner
                .For(m => m.CategoryID = categoryID)
                .ShouldNotHaveErrorsFor(m => m.CategoryID);
    }
}