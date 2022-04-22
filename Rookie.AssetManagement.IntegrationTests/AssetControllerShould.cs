using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.IntegrationTests.Common;
using Rookie.AssetManagement.IntegrationTests.TestData;
using Rookie.AssetManagement.Tests;
using Xunit;

namespace Rookie.AssetManagement.IntegrationTests
{
    public class AssetControllerShould : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly BaseRepository<User> _userRepository;
        private readonly BaseRepository<Asset> _assetRepository;
        private readonly BaseRepository<AssetCategory> _assetCategoryRepository;
        private readonly IMapper _mapper;
        private readonly AssetService _assetService;
        private readonly AssetCategoryService _assetCategoryService;
        private readonly AssetController _assetController;
        private readonly HttpContextAccessor _httpContext;
        public AssetControllerShould(SqliteInMemoryFixture fixture)
        {
            fixture.CreateDatabase();
            _dbContext = fixture.Context;
            _assetRepository = new BaseRepository<Asset>(_dbContext);
            _assetCategoryRepository = new BaseRepository<AssetCategory>(_dbContext);
            _userRepository = new BaseRepository<User>(_dbContext);
            _httpContext = new HttpContextAccessor();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();

            _assetService = new AssetService(_assetRepository, _mapper, _userRepository,_assetCategoryRepository);
            _assetCategoryService = new AssetCategoryService(_assetCategoryRepository, _mapper);
            _assetController = new AssetController(_assetService, _assetCategoryService);
            AssetArrangeData.InitAssetData(_dbContext);
            AssetArrangeData.InitUserData(_dbContext);
            AddClaims();
        }

        [Fact]
        public async void GetAssets_ValidCall_ReturnPagedResponse()
        {
            //arrange
            var query = new AssetQueryCriteria()
            {
                Page = 1,
                Limit = 5,
                SortOrder = SortOrderEnumDto.Accsending,
                SortColumn = "Id"
            };

            //act
            var result = await _assetController.GetAssets(query, new CancellationToken());
            //assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<PagedResponseModel<AssetDTO>>(actionResult.Value);
            Assert.Equal(5, returnValue.Items.Count());
        }

        [Fact]
        public async void GetAssetCategories_ValidCall_ReturnPagedResponse()
        {
            //arrange

            //act
            var result = await _assetController.GetAssetCategories();
            //assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<AssetCategoryDTO>>(actionResult.Value);
            Assert.Equal(3, returnValue.Count);
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
            _assetController.ControllerContext = controllerContext;
        }

        [Fact]
        public async Task CreateAsset_ReturnsStatusCode200Ok_WhenValidUser()
        {
            // Arrange
            var assetCreateRequest = AssetArrangeData.GetCreateNewAssetDto();

            //Act
            var actual = (OkObjectResult)await _assetController.Create(assetCreateRequest);

            //Assert
            actual.Should().NotBeNull();
            actual.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CreateAsset_ReturnsStatusCode400BadRequest_WhenInValidUser()
        {
            //Arrange          
            var assetCreateRequest = AssetArrangeData.GetInValidCreateNewAssetDto();

            //Act
            var actual = (BadRequestObjectResult)await _assetController.Create(assetCreateRequest);

            //Assert
            actual.Should().NotBeNull();
            actual.StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task UpdateAsset_ReturnsStatusCode200Ok_WhenValidAsset()
        {
            // Arrange
            var existedId = AssetArrangeData.ExistedAssetId;
            var assetEditRequest = AssetArrangeData.GetValidUpdateAssetDto();

            //Act
            var actual = await _assetController.Update(existedId, assetEditRequest);

            //Assert
            actual.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            actual.Should().NotBeNull();

            var actionResult = Assert.IsType<OkObjectResult>(actual.Result);
            var returnValue = Assert.IsType<AssetDTO>(actionResult.Value);

            returnValue.Name.Equals(assetEditRequest.Name);
            returnValue.Specification.Equals(assetEditRequest.Specification);
            returnValue.InstallDate.Equals(assetEditRequest.InstallDate);
            returnValue.State.Equals(assetEditRequest.State);
        }

        [Fact]
        public async Task UpdateAsset_ReturnsStatusCode400BadRequest_WhenInValidAsset()
        {
            // Arrange
            var existedId = AssetArrangeData.ExistedAssetId;
            var assetEditRequest = AssetArrangeData.GetInValidUpdateAssetDto();

            //Act
            var actual = await _assetController.Update(existedId, assetEditRequest);

            //Assert
            actual.Result.Should().HaveStatusCode(StatusCodes.Status400BadRequest);
            var actionResult = Assert.IsType<BadRequestObjectResult>(actual.Result);
            actionResult.Value.Should().NotBeNull();
        }
        [Fact]
        public async Task DeleteAsset_ReturnsStatusCode200Ok_WhenValidIdAsset()
        {
            // Arrange
            var existedId = 1;

            //Act
            var actual = (OkObjectResult)await _assetController.Delete(existedId);

            //Assert
            actual.Should().HaveStatusCode(StatusCodes.Status200OK);
            actual.StatusCode.Should().Be(200);
        }

    }
}
