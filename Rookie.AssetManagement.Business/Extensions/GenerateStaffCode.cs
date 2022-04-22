using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Rookie.AssetManagement.Business.Extensions
{
    public static class GenerateStaffCodeExtension
    {
        public static string GenerateStaffCode(UserManager<User> _userManager){
            var getMaxCode = _userManager.Users.FirstOrDefault(s=>s.Id==_userManager.Users.Max(x=>x.Id));
            int newCode=1;
            if(getMaxCode!=null){
                var code = _userManager.Users.Where(s=>s.Id==getMaxCode.Id).FirstOrDefault().StaffCode.Substring(2,4);
                newCode=Convert.ToInt32(code) + 1;
                string staffCode = "SD"+String.Format("{0:D4}", newCode);
                return staffCode;
            }
            else{
                string staffCode = "SD"+String.Format("{0:D4}", newCode);
                return staffCode; 
            }
            
        }
    }
}
