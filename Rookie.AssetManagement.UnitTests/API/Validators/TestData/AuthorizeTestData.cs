using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.UnitTests.API.Validators.TestData
{
    public static class AuthorizeTestData
    {


        public static IEnumerable<object[]> InvalidUserLoginDTOWithNoUsernameAndPassword()
        {
            return new object[][]
            {
                new object[]
                {
                    null,
                    null,
                    "UserName is required",
                    "Password is required",
                },
            };
        }
        public static IEnumerable<object[]> InvalidUserLoginDTOWithNoUsername()
        {
            return new object[][]
            {
                new object[]
                {
                    null,
                    "123456",
                    "UserName is required",
                },
            };
        }
        public static IEnumerable<object[]> InvalidUserLoginDTOWithNoPassword()
        {
            return new object[][]
            {
                new object[]
                {
                    "adminhcm",
                    null,
                    "Password is required",
                },
            };
        }
        public static IEnumerable<object[]> InvalidUserChangePasswordDTO()
        {
            return new object[][]
            {
                new object[]
                {
                    null,
                    null,
                    "Current Password is required",
                    "New Password is required",
                },
            };
        }
        public static IEnumerable<object[]> InvalidUserChangePasswordDTONoCurrentPassword()
        {
            return new object[][]
            {
                new object[]
                {
                    null,
                    "newPassword",
                    "Current Password is required",
                },
            };
        }
        public static IEnumerable<object[]> InvalidUserChangePasswordDTONoNewPassword()
        {
            return new object[][]
            {
                new object[]
                {
                    "newPassword",
                    null,
                    "New Password is required",
                },
            };
        }
        public static IEnumerable<object[]> ValidUserChangePasswordDTO()
        {
            return new object[][]
            {
                new object[]
                {
                    "currentPassword",
                    "newPassword",
                },
            };
        }
        public static IEnumerable<object[]> ValidUserLoginDTO()
        {
            return new object[][]
            {
                new object[]
                {
                    "adminhcm",
                    "123456",
                },
            };
        }


        public static User GetUser()
        {
            return new User()
            {
                StaffCode = "SD0001",
                UserName = "adminhcm",
                FirstName = "FirstName",
                LastName = "LassName",
                Location = (DataAccessor.Enums.UserLocationEnum)1,
                JoinDate = DateTime.Now,
                Gender = (DataAccessor.Enums.UserGenderEnum)1,
                DOB = DateTime.Parse("01-01-2000"),
                Email = "adminhcm@gmail.com",
                EmailConfirmed = true,
                FirstLogin = true,
                Type = (DataAccessor.Enums.UserTypeEnum)1,
                IsDisable = false
            };
        }
        public static UserLoginDTO GetValidUsersLoginDTO()
        {
            return
                new UserLoginDTO
                {
                    UserName = "adminhcm",
                    Password = "123456",
                };
        }
    }
}
