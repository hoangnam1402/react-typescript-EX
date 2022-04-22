using AutoMapper;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.Business
{
    public class AssignmentServiceShould
    {
        private readonly AssignmentService _assignmentService;
        private readonly Mock<IBaseRepository<Asset>> _assetRepository;
        private readonly Mock<IBaseRepository<User>> _userRepository;
        private readonly Mock<IBaseRepository<AssetCategory>> _assetcateRepository;
        private readonly Mock<IBaseRepository<Assignment>> _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentServiceShould()
        {
            _assetRepository = new Mock<IBaseRepository<Asset>>();
            _userRepository = new Mock<IBaseRepository<User>>();
            _assetcateRepository = new Mock<IBaseRepository<AssetCategory>>();
            _assignmentRepository = new Mock<IBaseRepository<Assignment>>();    
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = configMapper.CreateMapper();
            _assignmentService = new AssignmentService(
                _assignmentRepository.Object,
                _assetRepository.Object,
                _mapper,
                _userRepository.Object,
                _assetcateRepository.Object);
        }

        [Fact]
        public async void GetByPageAsync_ValidCallWithUserFromHCM_ReturnAssignmentListFromHCM()
        {
            //arrange
            var query = new AssignmentQueryCriteria()
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

            var assignmentMock = AssignmentTestData.GetAssignments().AsQueryable().BuildMock();
            _assignmentRepository
              .Setup(x => x.Entities)
              .Returns(assignmentMock.Object);

            //act

            var result = await _assignmentService.GetByPageAsync(query, new CancellationToken(), userId);
            //assert

            Assert.NotNull(result);
            Assert.IsType<PagedResponseModel<AssignmentDTO>>(result);
            Assert.IsType<List<AssignmentDTO>>(result.Items);
            Assert.Equal(5, result.Items.Count());
            Assert.True(result.Items.All(x => x.Location == DataAccessor.Enums.UserLocationEnum.HCM));
        }

        [Fact]
        public async void GetByPageAsync_ValidCallWithUserFromHN_ReturnAssignmentListFromHN()
        {
            //arrange
            var query = new AssignmentQueryCriteria()
            {
                Page = 1,
                Limit = 5,
                SortOrder = SortOrderEnumDto.Accsending,
                SortColumn = "Id",
                AssignedDate = DateTime.Now,
            };

            var userId = 1;

            var userList = new List<User>()
            {
                new User() { Id = userId,Location=DataAccessor.Enums.UserLocationEnum.HN}
            };

            _userRepository.Setup(x => x.Entities).Returns(userList.AsQueryable());

            var assignmentMock = AssignmentTestData.GetAssignments().AsQueryable().BuildMock();
            _assignmentRepository
              .Setup(x => x.Entities)
              .Returns(assignmentMock.Object);

            //act

            var result = await _assignmentService.GetByPageAsync(query, new CancellationToken(), userId);
            
            //assert

            Assert.NotNull(result);
            Assert.IsType<PagedResponseModel<AssignmentDTO>>(result);
            Assert.IsType<List<AssignmentDTO>>(result.Items);
            Assert.Equal(5, result.Items.Count());
            Assert.True(result.Items.All(x => x.Location == DataAccessor.Enums.UserLocationEnum.HN));

        }
        [Fact]
        public async void ResponseToAssignment_ValidCallAndAcceptAssignment_Return200AndCorrectState()
        {
            //arrange
            var dto = new AssignmentResponseDTO()
            {
                AssignmentID = 1,
                Response = DataAccessor.Enums.AssignmentResponseEnum.Accepted,
            };
            var userId = 14;

            var userList = new List<User>()
            {
                new User() { Id = userId,Location=DataAccessor.Enums.UserLocationEnum.HN},
            };

            _userRepository.Setup(x => x.Entities).Returns(userList.AsQueryable());
            var assignmentMock = AssignmentTestData.GetAssignments().AsQueryable().BuildMock();
            _assignmentRepository
             .Setup(x => x.Entities)
             .Returns(assignmentMock.Object);

            _assignmentRepository
                      .Setup(x => x.Add(It.IsAny<Assignment>()))
                .ReturnsAsync(new Assignment());
            //act
            var result = await _assignmentService.RespondToAssigment(dto,userId);
            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(16,result.Asset.Id);
            Assert.Equal(DataAccessor.Enums.AssignmentStateEnum.Accepted, result.State);
            Assert.Equal(DataAccessor.Enums.AssetStateEnum.Assigned,result.Asset.State);
        }


        [Fact]
        public async void ResponseToAssignment_ValidCallAndDeclineAssignment_Return200AndCorrectState()
        {
            //arrange
            var dto = new AssignmentResponseDTO()
            {
                AssignmentID = 1,
                Response = DataAccessor.Enums.AssignmentResponseEnum.Declined,
            };
            var userId = 14;

            var userList = new List<User>()
            {
                new User() { Id = userId,Location=DataAccessor.Enums.UserLocationEnum.HN},
            };

            _userRepository.Setup(x => x.Entities).Returns(userList.AsQueryable());
            var assignmentMock = AssignmentTestData.GetAssignments().AsQueryable().BuildMock();
            _assignmentRepository
             .Setup(x => x.Entities)
             .Returns(assignmentMock.Object);

            _assignmentRepository
                      .Setup(x => x.Add(It.IsAny<Assignment>()))
                .ReturnsAsync(new Assignment());
            //act
            var result = await _assignmentService.RespondToAssigment(dto, userId);
            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(16, result.Asset.Id);
            Assert.Equal(DataAccessor.Enums.AssignmentStateEnum.Declined, result.State);
            Assert.Equal(DataAccessor.Enums.AssetStateEnum.Available, result.Asset.State);

        }
        [Fact]
        public async Task GetByPageForHomeAsync_ValidCallWithUserFromHCM_ReturnAssignmentListFromHCM()
        {
            var query = new AssignmentQueryCriteria()
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

            var assignmentMock = AssignmentTestData.GetAssignments().AsQueryable().BuildMock();
            _assignmentRepository
              .Setup(x => x.Entities)
              .Returns(assignmentMock.Object);

            //act

            var result = await _assignmentService.GetByPageForHomeAsync(query, new CancellationToken(), userId);
            //assert

            Assert.NotNull(result);
            Assert.IsType<PagedResponseModel<AssignmentDTO>>(result);
            Assert.IsType<List<AssignmentDTO>>(result.Items);
            Assert.Single(result.Items);
            Assert.True(result.Items.All(x => x.Location == DataAccessor.Enums.UserLocationEnum.HCM));
        }

        [Fact]
        public async Task GetByPageForHomeAsync_ValidCallWithUserFromHN_ReturnAssignmentListFromHN()
        {
            var query = new AssignmentQueryCriteria()
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

            var assignmentMock = AssignmentTestData.GetAssignments().AsQueryable().BuildMock();
            _assignmentRepository
              .Setup(x => x.Entities)
              .Returns(assignmentMock.Object);

            //act

            var result = await _assignmentService.GetByPageForHomeAsync(query, new CancellationToken(), userId);
            //assert

            Assert.NotNull(result);
            Assert.IsType<PagedResponseModel<AssignmentDTO>>(result);
            Assert.IsType<List<AssignmentDTO>>(result.Items);
            Assert.Single(result.Items);
            Assert.True(result.Items.All(x => x.Location == DataAccessor.Enums.UserLocationEnum.HN));
        }

        [Fact]
        public async Task CreateAssignment_Success_ReturnNewAssignment()
        {
            //Arrange
            var assignmentsMock = AssignmentTestData.GetAssignments().AsQueryable().BuildMock();

            _assignmentRepository
                  .Setup(x => x.Entities)
                  .Returns(assignmentsMock.Object);

            _assignmentRepository
                .Setup(x => x.Add(It.IsAny<Assignment>()))
                .Returns(Task.FromResult(AssignmentTestData.GetCreateAssignment()));

            var assignmentsUserMock = AssignmentTestData.GetUsers().AsQueryable().BuildMock();
            _userRepository
              .Setup(x => x.Entities)
              .Returns(assignmentsUserMock.Object);

            var assignmentsAssetMock = AssignmentTestData.GetAssets().AsQueryable().BuildMock();
            _assetRepository
                .Setup(x => x.Entities)
                .Returns(assignmentsAssetMock.Object);
            //Act
            var result = await _assignmentService.CreateAssignment(
                AssignmentTestData.GetCreateAssignmentDto(), 1
            );

            //Assert
            Assert.Equal(27, result.AssetID);
            Assert.Equal("Assign asset to this staff.", result.Note);
            Assert.Equal(2, result.AssignToID);
        }

        [Fact]
        public async Task UpdateAsync_AssignmentIsNull_ReturnKeyNotFoundException()
        {
            //Arrange
            var inexistedAssignmentId = 10000;
            var assignmentsMock = AssignmentTestData.GetAssignments().AsQueryable().BuildMock();
            var userid = 1;

            _assignmentRepository
                  .Setup(x => x.Entities)
                  .Returns(assignmentsMock.Object);

            //Act
            Func<Task> act = async() => await _assignmentService.UpdateAsync(
                inexistedAssignmentId, 
                AssignmentTestData.GetCreateAssignmentDto(), 
                userid);

            //Assert
            await act.Should().ThrowAsync<Exception>();
            _assignmentRepository.Verify(
                mock => mock.Update(new Assignment()),
                Times.Never()
            );
        }

        [Fact]
        public async Task UpdateAsync_AssignmentIsNotNull_ReturnUser()
        {
            ///Arrange
            var existedAssignmentId = 2;
            var assignmentsMock = AssignmentTestData.GetAssignments().AsQueryable().BuildMock();
            var userid = 1;

            _assignmentRepository
                .Setup(x => x.Entities)
                .Returns(assignmentsMock.Object);

            _assignmentRepository
                .Setup(x => x.Update(It.IsAny<Assignment>()))
                .Returns(Task.FromResult<Assignment>(AssignmentTestData.GetCreateAssignment()));

            //Act
            var result = await _assignmentService.UpdateAsync(
                existedAssignmentId, AssignmentTestData.GetCreateAssignmentDto(), userid);

            //Assert
            Assert.NotNull(result);
            result.AssetID.Equals(AssignmentTestData.GetCreateAssignmentDto().AssetID);
            result.AssignToID.Equals(AssignmentTestData.GetCreateAssignmentDto().AssignToID);
            result.AssignDate.Equals(AssignmentTestData.GetCreateAssignmentDto().AssignDate);
            result.Note.Equals(AssignmentTestData.GetCreateAssignmentDto().Note);
        }

        public async Task DeleteAssignment_Unsuccess_ReturnFalse()
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
            Func<Task> act = async () => await _assignmentService.DeleteAssignment(existedAssetId);

            //Assert
            act.Should().Throw<ErrorException>();

        }

    }
}
