using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Extensions
{
    public static class UserFullNameExtension
    {
        public static string GetFullName(this User user)
        {
            return user.FirstName + " " + user.LastName;
        }
    }
}
