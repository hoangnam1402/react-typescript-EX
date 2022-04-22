using System.Threading.Tasks;
using Rookie.AssetManagement.DataAccessor.Entities;
using Microsoft.AspNetCore.Identity;

namespace Rookie.AssetManagement.Constants
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole<int>(Roles.Staff.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(Roles.Admin.ToString()));
        }
    }
}