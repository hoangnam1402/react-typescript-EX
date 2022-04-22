using AutoMapper;
using MockQueryable.Moq;
using Moq;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts.Dtos;
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
    public class AssetCategoryServiceShould
    {
        private readonly Mock<IBaseRepository<AssetCategory>> _repository;
        private readonly IMapper _mapper;
        private readonly AssetCategoryService _service;
        public AssetCategoryServiceShould()
        {
            _repository = new Mock<IBaseRepository<AssetCategory>>();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = configMapper.CreateMapper();

            _service = new AssetCategoryService(_repository.Object, _mapper);
        }

        [Fact]
        public async void GetAll_ValidCall_ReturnListCategory()
        {
            //arrange
            var assetMock = AssetTestData.GetAssetCategories().AsQueryable().BuildMock();
            _repository
              .Setup(x => x.GetAll())
              .ReturnsAsync(assetMock.Object);
            //act
            var result = await _service.GetAll();
            //assert

            Assert.NotNull(result);
            Assert.IsType<List<AssetCategoryDTO>>(result);
            Assert.Equal(3, result.Count);
        }
    }
}
