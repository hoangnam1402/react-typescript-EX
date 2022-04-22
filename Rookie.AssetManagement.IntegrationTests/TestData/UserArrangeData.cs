using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Rookie.AssetManagement.Constants;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public static class UserArrangeData
    {
        public static void InitUserData(ApplicationDbContext dbContext)
        {
            User userHCM = new User
            {
                Id = 1,
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
            User userHN = new User
            {
                Id = 2,
                StaffCode = "SD0001",
                UserName = "adminhcm",
                FirstName = "FirstName",
                LastName = "LassName",
                Location = (DataAccessor.Enums.UserLocationEnum)2,
                JoinDate = DateTime.Now,
                Gender = (DataAccessor.Enums.UserGenderEnum)1,
                DOB = DateTime.Parse("01-01-2000"),
                Email = "adminhcm@gmail.com",
                EmailConfirmed = true,
                FirstLogin = true,
                Type = (DataAccessor.Enums.UserTypeEnum)1,
                IsDisable = false
            };
            dbContext.Users.Add(userHCM);
            dbContext.SaveChanges();
            dbContext.Users.Add(userHN);
            dbContext.SaveChanges();
        }

        public static List<User> GetSeedUsersData()
        {
            var users = new List<User>()
            {
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
                },
                new User
                {
                    Id = 3,
                    StaffCode = "SD0003",
                    UserName = "staffhn",
                    FirstName = "FirstName",
                    LastName = "LassName",
                    Location = UserLocationEnum.HN,
                    JoinDate = DateTime.Now,
                    Gender = UserGenderEnum.Male,
                    DOB = DateTime.Parse("01-01-2000"),
                    Email = "staffcm@gmail.com",
                    EmailConfirmed = true,
                    FirstLogin = true,
                    Type = UserTypeEnum.Staff
                },
                new User()
                {
                    Id = 4,
                    StaffCode = "SD0004",
                    UserName = "staffhcm",
                    FirstName = "FirstName",
                    LastName = "LassName",
                    Location = UserLocationEnum.HCM,
                    JoinDate = DateTime.Now,
                    Gender = UserGenderEnum.Female,
                    DOB = DateTime.Parse("01-01-2000"),
                    Email = "staffhcm@gmail.com",
                    EmailConfirmed = true,
                    FirstLogin = true,
                    Type = UserTypeEnum.Staff
                },
                new User()
                {
                    Id = 5,
                    StaffCode = "SD0005",
                    UserName = "staffcm",
                    FirstName = "FirstName",
                    LastName = "LassName",
                    Location = UserLocationEnum.HCM,
                    JoinDate = DateTime.Now,
                    Gender = UserGenderEnum.Male,
                    DOB = DateTime.Parse("01-01-2000"),
                    Email = "staffcm@gmail.com",
                    EmailConfirmed = true,
                    FirstLogin = true,
                    Type = UserTypeEnum.Staff
                },
                new User()
                {
                    Id = 6,
                    StaffCode = "SD0006",
                    UserName = "staffcm",
                    FirstName = "FirstName",
                    LastName = "LassName",
                    Location = UserLocationEnum.HCM,
                    JoinDate = DateTime.Now,
                    Gender = UserGenderEnum.Male,
                    DOB = DateTime.Parse("01-01-2000"),
                    Email = "staffcm@gmail.com",
                    EmailConfirmed = true,
                    FirstLogin = true,
                    Type = UserTypeEnum.Staff
                },
                 new User()
                {
                     Id = 7,
                    StaffCode = "SD0007",
                    UserName = "staffcm",
                    FirstName = "FirstName",
                    LastName = "LassName",
                    Location = UserLocationEnum.HN,
                    JoinDate = DateTime.Now,
                    Gender = UserGenderEnum.Female,
                    DOB = DateTime.Parse("01-01-2000"),
                    Email = "staffcm@gmail.com",
                    EmailConfirmed = true,
                    FirstLogin = true,
                    Type = UserTypeEnum.Staff
                }
            };
            return users;
        }
        public static async Task<List<IdentityRole<int>>> SeedRoles(RoleManager<IdentityRole<int>> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole<int>(Roles.Staff.ToString()));
                await roleManager.CreateAsync(new IdentityRole<int>(Roles.Admin.ToString()));
            }
            return roleManager.Roles.ToList();
        }
        public static async void InitUsersData(ApplicationDbContext dbContext,
                                        RoleManager<IdentityRole<int>> roleManager)
        {
            var users = GetSeedUsersData();
            dbContext.Users.AddRange(users);
            var roles = await SeedRoles(roleManager);
            dbContext.SaveChanges();
        }

        public static UserQueryCriteriaDto GetUserQueryCriteriaDto()
        {
            return new UserQueryCriteriaDto()
            {
                Page = 1,
                Limit = 5,
                SortOrder = SortOrderEnumDto.Accsending,
                SortColumn = "Id"
            };
        }
        public static UserCreateDto GetCreateNewUserDto()
        {
            return new UserCreateDto() {
                FirstName = "FirstName",
                LastName = "LassName",
                JoinDate = Convert.ToDateTime("03/31/2022"),
                Gender = (DataAccessor.Enums.UserGenderEnum)1,
                DOB = DateTime.Parse("01-01-2000"),
                Type = (DataAccessor.Enums.UserTypeEnum)1,
            };
        }
        public static UserCreateDto GetInValidCreateNewUserDto()
        {
            return new UserCreateDto() {
                FirstName="",
                LastName="Nguyen Van",
                JoinDate= Convert.ToDateTime("03/27/2010"),
                DOB= Convert.ToDateTime("01/02/2000"),
                Gender= UserGenderEnum.Male,
                Type=UserTypeEnum.Staff
            };
        }
    }
}