﻿﻿using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using System.Collections.Generic;
using System;

namespace Rookie.AssetManagement.UnitTests.API.Validators.TestData
{
    public static class UserTestsData
    {
        public static List<User> GetUsers()
        {
            return new List<User>() {
               new User {
                   Id = 1,
                    StaffCode = "SD0001",
                    UserName = "adminhcm",
                    FirstName = "FirstName",
                    LastName = "LassName",
                    Location = UserLocationEnum.HCM,
                    JoinDate = DateTime.Now,
                    Gender = UserGenderEnum.Female,
                    DOB = DateTime.Parse("01-01-2000"),
                    Email = "adminhcm@gmail.com",
                    EmailConfirmed = true,
                    FirstLogin = true,
                    Type = UserTypeEnum.Admin
                },
                new User
                {
                    Id = 2,
                    StaffCode = "SD0002",
                    UserName = "adminhhn",
                    FirstName = "FirstName",
                    LastName = "LassName",
                    Location = UserLocationEnum.HN,
                    JoinDate = DateTime.Now,
                    Gender = UserGenderEnum.Male,
                    DOB = DateTime.Parse("01-01-2000"),
                    Email = "adminhcm@gmail.com",
                    EmailConfirmed = true,
                    FirstLogin = true,
                    Type = UserTypeEnum.Admin
                }
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
                Location = UserLocationEnum.HCM,
                JoinDate = Convert.ToDateTime("03/30/2022"),
                DOB = Convert.ToDateTime("01/02/2000"),
                Gender = UserGenderEnum.Male,
                Email = "adminhcm@gmail.com",
                EmailConfirmed = true,
                FirstLogin = true,
                Type = UserTypeEnum.Staff
            };
        }

        public static UserQueryCriteriaDto GetUserQueryCriteriaDto()
        {
            return new UserQueryCriteriaDto()
            {
                Limit = 5,
                Page = 1
            };
        }
        public static IEnumerable<object[]> ValidLastNames()
        {
            return new object[][]
            {
                new object[] { "Nguyen Van" },
                new object[] { "Nguyen Tran Thien" },
            };
        }
        public static IEnumerable<object[]> IsEmptyLastName()
        {
            return new object[][]
            {
                new object[] { 
                    "" ,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(UserCreateDto.LastName), 0),
                },
                new object[] { 
                    "",
                    string.Format(ErrorTypes.Common.RequiredError, nameof(UserCreateDto.LastName), 0)
                },
            };
        }
        public static IEnumerable<object[]> IsInValidLastName()
        {
            return new object[][]
            {
                new object[] { 
                    "abc abc @#" ,
                    string.Format(ErrorTypes.Common.SpecialCharacterError, nameof(UserCreateDto.LastName), 0),
                },
                new object[] { 
                    "abc1213",
                    string.Format(ErrorTypes.Common.SpecialCharacterError, nameof(UserCreateDto.LastName), 0)
                },
            };
        }
        public static IEnumerable<object[]> IsNullLastNames()
        {
            return new object[][]{
                new object[]
                {
                    null,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(UserCreateDto.LastName), 0),
                },
            };
            
        }

        public static IEnumerable<object[]> ValidFirstNames()
        {
            return new object[][]
            {
                new object[] { "A" },
                new object[] { "B" },
            };
        }
        public static IEnumerable<object[]> IsEmptyFirstNames()
        {
            return new object[][]
            {
                new object[] { 
                    "" ,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(UserCreateDto.FirstName), 0),
                },
                new object[] { 
                    "",
                    string.Format(ErrorTypes.Common.RequiredError, nameof(UserCreateDto.FirstName), 0)
                },
            };
        }
        public static IEnumerable<object[]> InValidFirstNames()
        {
            return new object[][]
            {
                new object[] { 
                    "abcb#$ " ,
                    string.Format(ErrorTypes.Common.SpecialCharacterError, nameof(UserCreateDto.FirstName), 0),
                },
                new object[] { 
                    "nguyen!",
                    string.Format(ErrorTypes.Common.SpecialCharacterError, nameof(UserCreateDto.FirstName), 0)
                },
            };
        }
        public static IEnumerable<object[]> IsNullFirstNames()
        {
            return new object[][]{
                new object[]
                {
                    null,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(UserCreateDto.FirstName), 0),
                },
            };
        }

        public static IEnumerable<object[]> ValidDOB()
        {
            return new object[][]
            {
                new object[] { Convert.ToDateTime("12/5/2000")},
                new object[] { Convert.ToDateTime("1/1/1990") },
            };
        }

        public static IEnumerable<object[]> InvalidDOB()
        {
            return new object[][]
            {
                new object[]
                {
                    Convert.ToDateTime("1/1/2020"),
                    string.Format(ErrorTypes.Common.DOBLessThan18),
                },
                new object[]
                {
                    Convert.ToDateTime("2/20/2006"),
                    string.Format(ErrorTypes.Common.DOBLessThan18),
                },
            };
        }
        public static IEnumerable<object[]> ValidJoinDate()
        {
            return new object[][]
            {
                new object[] { 
                    Convert.ToDateTime("12/5/2000"),
                    Convert.ToDateTime("03/29/2022")
                },
                new object[] { 
                    Convert.ToDateTime("1/1/1990"),
                    Convert.ToDateTime("03/24/2020")
                },
            };
        }

        public static IEnumerable<object[]> JoinDateIsSundayOrSaturday()
        {
            return new object[][]
            {
                new object[]
                {
                    Convert.ToDateTime("03/19/2022"),
                    string.Format(ErrorTypes.Common.JoinDateIsNotSaturdayOrSunDay),
                },
                new object[]
                {
                    Convert.ToDateTime("03/20/2022"),
                    string.Format(ErrorTypes.Common.JoinDateIsNotSaturdayOrSunDay),
                },
            };
        }
        public static IEnumerable<object[]> ValidType()
        {
            return new object[][]
            {
                new object[] { 
                    UserTypeEnum.Admin
                },
                new object[] { 
                    UserTypeEnum.Staff
                },
            };
        }

        public static IEnumerable<object[]> InValidType()
        {
            return new object[][]
            {
                new object[]
                {
                    null,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(UserCreateDto.Type), 0),
                },
            };
        }
        public static IEnumerable<object[]> ValidGender()
        {
            return new object[][]
            {
                new object[] { 
                    UserGenderEnum.Female
                },
                new object[] { 
                    UserGenderEnum.Male
                },
            };
        }

        public static IEnumerable<object[]> InValidGender()
        {
            return new object[][]
            {
                new object[]
                {
                    null,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(UserCreateDto.Gender), 0),
                },
            };
        }
        public static IEnumerable<object[]> JoinDateIsUnder18()
        {
            return new object[][]
            {
                new object[]
                {
                    Convert.ToDateTime("1/1/2000"),
                    Convert.ToDateTime("11/17/2010"),
                    string.Format(ErrorTypes.Common.JoinDateLessThan18YearsOld),
                },
                new object[]
                {
                    Convert.ToDateTime("2/20/2006"),
                    Convert.ToDateTime("8/1/2012"),
                    string.Format(ErrorTypes.Common.JoinDateLessThan18YearsOld),
                },
            };
        }
        public static UserCreateDto GetCreateNewUserDto()
        {
            return new UserCreateDto() {
                FirstName="Binh",
                LastName="Nguyen Van",
                JoinDate= Convert.ToDateTime("03/30/2022"),
                DOB= Convert.ToDateTime("01/02/2000"),
                Gender= UserGenderEnum.Male,
                Type=UserTypeEnum.Staff
            };
        }
        public static UserCreateDto GetInValidCreateNewUserDto()
        {
            return new UserCreateDto() {
                FirstName="Binh",
                LastName="Nguyen Van",
                JoinDate= Convert.ToDateTime("03/27/2022"),
                DOB= Convert.ToDateTime("01/02/2000"),
                Gender= UserGenderEnum.Male,
                Type=UserTypeEnum.Staff
            };
        }
    }
}