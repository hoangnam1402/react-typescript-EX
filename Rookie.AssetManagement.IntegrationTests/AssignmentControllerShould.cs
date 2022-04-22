using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.IntegrationTests.Common;
using Rookie.AssetManagement.IntegrationTests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Rookie.AssetManagement.Tests;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;

namespace Rookie.AssetManagement.IntegrationTests
{
    public class AssignmentControllerShould : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly BaseRepository<User> _userRepository;
        private readonly BaseRepository<Asset> _assetRepository;
        private readonly BaseRepository<AssetCategory> _assetCategoryRepository;
        private readonly BaseRepository<Assignment> _assignmentRepository;
        private readonly IMapper _mapper;
        private readonly AssetService _assetService;
        private readonly AssetCategoryService _assetCategoryService;
        private readonly AssignmentService _assignmentService;
        private readonly AssignmentController _assignmentController;
        private readonly HttpContextAccessor _httpContext;

        public AssignmentControllerShould(SqliteInMemoryFixture fixture)
        {
            fixture.CreateDatabase();
            _dbContext = fixture.Context;
            _assetRepository = new BaseRepository<Asset>(_dbContext);
            _assetCategoryRepository = new BaseRepository<AssetCategory>(_dbContext);
            _assignmentRepository = new BaseRepository<Assignment>(_dbContext);
            _userRepository = new BaseRepository<User>(_dbContext);
            _httpContext = new HttpContextAccessor();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();

            _assetService = new AssetService(_assetRepository, _mapper, _userRepository, _assetCategoryRepository);
            _assetCategoryService = new AssetCategoryService(_assetCategoryRepository, _mapper);
            _assignmentService = new AssignmentService(_assignmentRepository, _assetRepository, _mapper, _userRepository, _assetCategoryRepository);
            _assignmentController = new AssignmentController(_assignmentService);

            AssignmentArrangeData.InitUserData(_dbContext);
            AssignmentArrangeData.InitAssetData(_dbContext);
            AssignmentArrangeData.InitAssignmentData(_dbContext);
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
            _assignmentController.ControllerContext = controllerContext;
        }

        public void AddClaimsStaff()
        {
            var claims = new List<Claim>()
            {
                new Claim(UserClaims.Id,3.ToString()),
                new Claim(UserClaims.Role,Roles.Staff),
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
            _assignmentController.ControllerContext = controllerContext;
        }

        [Fact]
        public async void GetAssigment_ValidCall_ReturnPagedResponse()
        {
            //arrange
            var query = new AssignmentQueryCriteria()
            {
                Page = 1,
                Limit = 5,
                SortOrder = SortOrderEnumDto.Accsending,
                SortColumn = "Id"
            };

            //act
            var result = await _assignmentController.GetAssignments(query, new CancellationToken());
            //assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<PagedResponseModel<AssignmentDTO>>(actionResult.Value);
            Assert.Equal(4, returnValue.Items.Count());
        }

        [Fact]
        public async void RespondToAssignment_ValidCall_ReturnAssignmentWithCorrectState()
        {
            //arrange
            AddClaimsStaff();
            var dto = new AssignmentResponseDTO()
            {
                AssignmentID = 1,
                Response = AssignmentResponseEnum.Accepted
            };

            //act
            var result = await _assignmentController.RespondToAssignment(dto);

            //assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AssignmentDTO>(actionResult.Value);

            Assert.Equal((int)AssetStateEnum.Assigned, (int)returnValue.Asset.State);
            Assert.Equal((int)AssignmentStateEnum.Accepted, (int)returnValue.State);


        }
        [Fact]
        public async void GetAssignmentsForHomePage_ValidCall_ReturnPagedResponse()
        {
            //arrange
            var query = new AssignmentQueryCriteria()
            {
                Page = 1,
                Limit = 5,
                SortOrder = SortOrderEnumDto.Accsending,
                SortColumn = "Id"
            };

            //act
            var result = await _assignmentController.GetAssignmentsForHomePage(query, new CancellationToken());
            //assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<PagedResponseModel<AssignmentDTO>>(actionResult.Value);
            Assert.Equal(2, returnValue.Items.Count());
        }

        [Fact]
        public async Task CreateAssignment_ReturnsStatusCode200Ok_WhenValidUser()
        {
            // Arrange
            var assignmentCreateRequest = AssignmentArrangeData.GetCreateNewAssignmentDto();

            //Act
            var actual = (OkObjectResult)await _assignmentController.Create(assignmentCreateRequest);

            //Assert
            actual.Should().NotBeNull();
            actual.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CreateAssignment_ReturnsStatusCode400BadRequest_WhenInValidUser()
        {
            //Arrange          
            var assignmentCreateRequest = AssignmentArrangeData.GetInValidCreateNewAssignmentDto();

            //Act
            var actual = (BadRequestObjectResult)await _assignmentController.Create(assignmentCreateRequest);

            //Assert
            actual.Should().NotBeNull();
            actual.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteAssignment_ReturnsStatusCode200Ok_WhenValidIdAsset()
        {
            // Arrange
            var existedId = 1;

            //Act
            var actual = (OkObjectResult)await _assignmentController.Delete(existedId);

            //Assert
            actual.Should().HaveStatusCode(StatusCodes.Status200OK);
            actual.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task UpdateAssignment_ReturnsStatusCode200Ok_WhenValidAssignment()
        {
            // Arrange
            var existedid = 1;
            var assignmentEditRequest = AssignmentArrangeData.GetCreateNewAssignmentDto();

            //Act
            var actual = await _assignmentController.UpdateAssignment(existedid, assignmentEditRequest);

            //Assert
            actual.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            actual.Should().NotBeNull();

            var actionResult = Assert.IsType<OkObjectResult>(actual.Result);
            var returnValue = Assert.IsType<AssignmentDTO>(actionResult.Value);

            returnValue.AssetID.Equals(assignmentEditRequest.AssetID);
            returnValue.AssignToID.Equals(assignmentEditRequest.AssignToID);
            returnValue.AssignDate.Equals(assignmentEditRequest.AssignDate);
            returnValue.Note.Equals(assignmentEditRequest.Note);
        }

        [Fact]
        public async Task UpdateAssignment_ReturnsStatusCode400BadRequest_WhenInValidAssignment()
        {
            // Arrange
            var existedid = 1;
            var assignmentEditRequest = AssignmentArrangeData.GetInValidCreateNewAssignmentDto();

            //Act
            var actual = await _assignmentController.UpdateAssignment(existedid, assignmentEditRequest);

            //Assert
            actual.Result.Should().HaveStatusCode(StatusCodes.Status400BadRequest);
            var actionResult = Assert.IsType<BadRequestObjectResult>(actual.Result);
            actionResult.Value.Should().NotBeNull();
        }
    }
}
