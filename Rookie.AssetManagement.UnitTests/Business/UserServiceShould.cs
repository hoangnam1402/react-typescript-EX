using AutoMapper;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Xunit;
using System.Security.Claims;
using System.Linq;
using System.Threading;
namespace Rookie.AssetManagement.UnitTests.Business
{
    public class UserServiceShould
    {
        private readonly UserService _userService;
        private readonly Mock<IBaseRepository<User>> _userRepository;
        private readonly IMapper _mapper;
        private readonly Mock<UserManager<User>> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly Mock<IHttpContextAccessor> _httpcontext;

        public UserServiceShould()
        {
            var mockStore=Mock.Of<IUserStore<User>>();

            _userRepository = new Mock<IBaseRepository<User>>();
            _userManager = new Mock<UserManager<User>>(mockStore,
                null,null,null,null,null,null,null,null);
            _httpcontext=new Mock<IHttpContextAccessor>();

            var claims = new List<Claim>
            {
                new Claim("location", UserLocationEnum.HCM.ToString()),
            };

            _httpcontext.SetupGet(x=>x.HttpContext.User.Claims).Returns(claims);
            
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();

            _userService = new UserService(
                    _userRepository.Object,
                    _mapper,
                    _httpcontext.Object,
                    _userManager.Object,
                    _signInManager,
                    _roleManager
                );
        }

        [Fact]
        public async Task GetUserHcmAsyncShouldReturnObjectAsync()
        {
            //Arrange   
            var existedUserId = 1;
            var usersMock = UserTestsData.GetUsers().AsQueryable().BuildMock();
            var UserQueryCriteriaDto = UserTestsData.GetUserQueryCriteriaDto();
            _userRepository
                  .Setup(x => x.Entities)
                  .Returns(usersMock.Object);

            //Act
            var result = await _userService.GetByPageAsync(UserQueryCriteriaDto,
                new CancellationToken() , existedUserId);

            //Assert
            result.Should().NotBeNull();
            _userRepository.Verify(mock => mock.Entities, Times.AtLeastOnce());
        }

        [Fact]
        public async Task GetUserHnAsyncShouldReturnObjectAsync()
        {
            //Arrange   
            var existedUserId = 2;
            var usersMock = UserTestsData.GetUsers().AsQueryable().BuildMock();
            var UserQueryCriteriaDto = UserTestsData.GetUserQueryCriteriaDto();
            _userRepository
                  .Setup(x => x.Entities)
                  .Returns(usersMock.Object);

            //Act
            var result = await _userService.GetByPageAsync(UserQueryCriteriaDto,
                new CancellationToken(), existedUserId);

            //Assert
            result.Should().NotBeNull();
            _userRepository.Verify(mock => mock.Entities, Times.AtLeastOnce());
        }

        [Fact]
        public async Task RegisterUser_WithNullModel_ShouldThrowExceptionAsync()
        {
            Func<Task> act = async () => await _userService.RegisterUser(null);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task RegisterUser_WithValidModel_ShouldBeSuccessfullyAsync()
        {
            //Arrange
            _userManager
                .Setup(x => x.CreateAsync(It.IsAny<User>(),It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            //Act
            var result = await _userService.RegisterUser(UserTestsData.GetCreateNewUserDto());

            //Assert
            result.Should().NotBeNull();
            _userManager.Verify(mock => mock.CreateAsync(It.IsAny<User>(),It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task RegisterUser_WithInValidModel_ReturnNull()
        {
            //Arrange
            _userManager
                .Setup(x => x.CreateAsync(It.IsAny<User>(),It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Code = "null"}));

            //Act
            var result = await _userService.RegisterUser(UserTestsData.GetInValidCreateNewUserDto());

            //Assert
            result.Should().BeNull();
            _userManager.Verify(mock => mock.CreateAsync(It.IsAny<User>(),It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task RegisterUser_WithValidModel_ReturnKeyNotFoundException()
        {
            //Arrange
            var claims = new List<Claim>{};
            _httpcontext.SetupGet(x=>x.HttpContext.User.Claims).Returns(claims); 

            _userManager
                .Setup(x => x.CreateAsync(It.IsAny<User>(),It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Code = "null"}));

            //Act
            Func<Task> act = async () => await _userService.RegisterUser(UserTestsData.GetCreateNewUserDto());

            //Assert
            act.Should().Throw<KeyNotFoundException>();
            _userManager.Verify(mock => mock.CreateAsync(It.IsAny<User>(),It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task UpdateAsync_UserIsNull_ReturnKeyNotFoundException()
        {
            //Arrange
            var inexistedUserId = 10000;
            var usersMock = UserTestsData.GetUsers().AsQueryable().BuildMock();

            _userRepository
                  .Setup(x => x.Entities)
                  .Returns(usersMock.Object);

            //Act
            Func<Task> act = async() => await _userService.UpdateAsync(
                inexistedUserId, UserTestsData.GetCreateNewUserDto());

            //Assert
            await act.Should().ThrowAsync<Exception>();
            _userRepository.Verify(
                mock => mock.Update(new User()),
                Times.Never()
            );
        }

        [Fact]
        public async Task UpdateAsync_UserIsNotNull_ReturnUser()
        {
            //Arrange
            var existedUserId = 1;
            var usersMock = UserTestsData.GetUsers().AsQueryable().BuildMock();

            _userRepository
                .Setup(x => x.Entities)
                .Returns(usersMock.Object);

            _userRepository
                .Setup(x => x.Update(It.IsAny<User>()))
                .Returns(Task.FromResult<User>(UserTestsData.GetUser()));

            //Act
            var result = await _userService.UpdateAsync(
                existedUserId, UserTestsData.GetCreateNewUserDto());

            //Assert
            result.Should().NotBeNull();
            result.DOB.Equals(UserTestsData.GetCreateNewUserDto().DOB);
            result.JoinDate.Equals(UserTestsData.GetCreateNewUserDto().JoinDate);
            result.Gender.Equals(UserTestsData.GetCreateNewUserDto().Gender);
            result.Type.Equals(UserTestsData.GetCreateNewUserDto().Type);
        }


    }
}
