using System;
using System.Threading.Tasks;
using Rookie.AssetManagement.Constants;
using Microsoft.AspNetCore.Identity;
using Rookie.AssetManagement.DataAccessor.Entities;
using System.Linq;

namespace Rookie.AssetManagement.DataAccessor.Data.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var adminHCM = new User
                {
                    StaffCode = "SD0001",
                    UserName = "adminhcm",
                    FirstName = "FirstName",
                    LastName = "LassName",
                    Location = (Enums.UserLocationEnum)1,
                    JoinDate = DateTime.Now,
                    Gender = (Enums.UserGenderEnum)1,
                    DOB = DateTime.Parse("01-01-2000"),
                    Email = "adminhcm@gmail.com",
                    EmailConfirmed = true,
                    FirstLogin = true,
                    Type = (Enums.UserTypeEnum)1,
                    IsDisable = false
                };

                await userManager.CreateAsync(adminHCM, "123456");
            }
        }
    }
}