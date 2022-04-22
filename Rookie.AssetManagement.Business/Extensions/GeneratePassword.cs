using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Extensions
{
    public static class GeneratePasswordExtension
    {
        public static string GeneratePassword(string userName,DateTime dob){
            var password=userName+"@"+String.Format("{0:dd}",dob)+String.Format("{0:MM}",dob)+String.Format("{0:yyyy}",dob);
            return password;
        }
    }
}
