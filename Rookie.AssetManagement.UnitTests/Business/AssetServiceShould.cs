using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using MockQueryable.Moq;
using Moq;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.Business
{
    public class AssetServiceShould
    {
        private readonly AssetService _assetService;
        private readonly Mock<IBaseRepository<Asset>> _assetRepository;
        private readonly Mock<IBaseRepository<User>> _userRepository;
        private readonly Mock<IBaseRepository<AssetCategory>> _assetcateRepository;
        private readonly IMapper _mapper;
        public AssetServiceShould()
        {
            _assetRepository = new Mock<IBaseRepository<Asset>>();
            _userRepository = new Mock<IBaseRepository<User>>();
            _assetcateRepository = new Mock<IBaseRepository<AssetCategory>>();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = configMapper.CreateMapper();
            _assetService = new AssetService(
                _assetRepository.Object,
                _mapper,
                _userRepository.Object,
                _assetcateRepository.Object);
        }

        [Fact]
        public async void GetByPageAsync_ValidCallWithUserFromHCM_ReturnAssetListFromHCM()
        {
            //arrange
            var query = new AssetQueryCriteria()
            {
                Page = 1,
                Limit = 5,
                SortOrder = SortOrderEnumDto.Accsending,
                SortColumn = "Id"
            };

            var userId = 1;

            var userList = new List<User>()
            {
                new User() { Id = userId,Location=DataAccessor.Enums.UserLocationEnum.HCM}
            };

            _userRepository.Setup(x => x.Entities).Returns(userList.AsQueryable());


            var assetMock = AssetTestData.GetAssets().AsQueryable().BuildMock();
            _assetRepository
              .Setup(x => x.Entities)
              .Returns(assetMock.Object);
            //act

            var result = await _assetService.GetByPageAsync(query, new CancellationToken(), userId);
            //assert

            Assert.NotNull(result);
            Assert.IsType<PagedResponseModel<AssetDTO>>(result);
            Assert.IsType<List<AssetDTO>>(result.Items);
            Assert.Equal(5, result.Items.Count());
            Assert.True(result.Items.All(x => x.Location == DataAccessor.Enums.UserLocationEnum.HCM));
        }


        [Fact]
        public async void GetByPageAsync_ValidCallWithUserFromHN_ReturnAssetListFromHN()
        {
            //arrange
            var query = new AssetQueryCriteria()
            {
                Page = 1,
                Limit = 5,
                SortOrder = SortOrderEnumDto.Accsending,
                SortColumn = "Id"
            };

            var userId = 1;

            var userList = new List<User>()
            {
                new User() { Id = userId,Location=DataAccessor.Enums.UserLocationEnum.HN}
            };

            _userRepository.Setup(x => x.Entities).Returns(userList.AsQueryable());


            var assetMock = AssetTestData.GetAssets().AsQueryable().BuildMock();
            _assetRepository
              .Setup(x => x.Entities)
              .Returns(assetMock.Object);
            //act

            var result = await _assetService.GetByPageAsync(query, new CancellationToken(), userId);
            //assert

            Assert.NotNull(result);
            Assert.IsType<PagedResponseModel<AssetDTO>>(result);
            Assert.IsType<List<AssetDTO>>(result.Items);
            Assert.Equal(5, result.Items.Count());
            Assert.True(result.Items.All(x => x.Location == DataAccessor.Enums.UserLocationEnum.HN));
        }
        [Fact]
        public async Task CreateAsset_Success_ReturnNewAsset()
        {
            //Arrange
            var assetsMock = AssetTestData.GetAssets().AsQueryable().BuildMock();

            _assetRepository
                  .Setup(x => x.Entities)
                  .Returns(assetsMock.Object);

            _assetRepository
                .Setup(x => x.Add(It.IsAny<Asset>()))
                .Returns(Task.FromResult(AssetTestData.GetCreateAsset()));

            var assetsCategoryMock = AssetTestData.GetAssetCategories().AsQueryable().BuildMock();

            _assetcateRepository
              .Setup(x => x.Entities)
              .Returns(assetsCategoryMock.Object);

            //Act
            var result = await _assetService.CreateAsset(
                AssetTestData.GetCreateAssetDto(), 1
            );

            //Assert
            Assert.Equal("Personal Computer", result.Name);
            Assert.Equal(result.InstallDate, DateTime.Parse("03/30/2022"));
            Assert.Equal("Specification of Monitor", result.Specification);
            Assert.Equal(AssetStateEnum.Assigned, result.State);
            Assert.Equal(result.CategoryID, 1);
        }

        [Fact]
        public async Task DeleteAsset_Unsuccess_ReturnFalse()
        {
            //Arrange
            var existedAssetId = 16;
            var assetsMock = AssetTestData.GetAssets().AsQueryable().BuildMock();

            _assetRepository
                  .Setup(x => x.Entities)
                  .Returns(assetsMock.Object);

            _assetRepository
                .Setup(x => x.Update(It.IsAny<Asset>()))
                .Returns(Task.FromResult<Asset>(AssetTestData.GetAsset()));
            //Act
            Func<Task> act = async () => await _assetService.DeleteAsset(existedAssetId);

            //Assert
            act.Should().Throw<ErrorException>();
            
        }
    }
}
