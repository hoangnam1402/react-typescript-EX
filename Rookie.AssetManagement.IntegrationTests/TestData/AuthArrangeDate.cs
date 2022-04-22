using Microsoft.AspNetCore.Identity;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public static class AuthArrangeData
    {
        public static async Task<List<User>> GetSeedUsersDataAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var adminHCM = new User
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

                await userManager.CreateAsync(adminHCM, "123456");

                var staff = new User
                {
                    StaffCode = "SD0001",
                    UserName = "staff",
                    FirstName = "FirstName",
                    LastName = "LassName",
                    Location = (DataAccessor.Enums.UserLocationEnum)1,
                    JoinDate = DateTime.Now,
                    Gender = (DataAccessor.Enums.UserGenderEnum)1,
                    DOB = DateTime.Parse("01-01-2000"),
                    Email = "staff@gmail.com",
                    EmailConfirmed = true,
                    FirstLogin = true,
                    Type = (DataAccessor.Enums.UserTypeEnum)2,
                    IsDisable = false
                };

                await userManager.AddToRoleAsync(adminHCM,Roles.Admin.ToString());
                await userManager.AddToRoleAsync(staff, Roles.Staff.ToString());
            }
            return (List<User>)userManager.Users;
        }
        public static async Task<List<IdentityRole<int>>> SeedRole(RoleManager<IdentityRole<int>> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole<int>(Roles.Staff.ToString()));
                await roleManager.CreateAsync(new IdentityRole<int>(Roles.Admin.ToString()));
            }
            return roleManager.Roles.ToList();
        }
        public static async void InitUsersData(ApplicationDbContext dbContext,UserManager<User> userManager, 
            RoleManager<IdentityRole<int>> roleManager)
        {
            var roles = await SeedRole(roleManager);
            var users = await GetSeedUsersDataAsync(userManager);
            dbContext.SaveChanges();
        }

        public static string ValidToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdGFmZkNvZGUiOiJTRDAwMDEiLCJ1c2VybmFtZSI6ImFkbWluaGNtIiwibG9jYXRpb24iOiJIQ00iLCJ1aWQiOiI0Iiwicm9sZVR5cGUiOiJBRE1JTiIsImZ1bGxOYW1lIjoiRmlyc3ROYW1lIExhc3NOYW1lIiwiZmlyc3RMb2dpbiI6IkZhbHNlIiwiaXNEaXNhYmxlIjoiRmFsc2UiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBRE1JTiIsImV4cCI6MTY0ODcxMDczMCwiaXNzIjoiUm9va2llLkFzc2V0TWFuYWdlbWVudCIsImF1ZCI6IlJvb2tpZS5Bc3NldE1hbmFnZW1lbnQuVXNlciJ9.dQw3eaUyprvgnF1SkLMaeVu1GJIaLmiaDMVpnVosXt0";
        public static User ValidUser()
        {
            return new User
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
    }
}
