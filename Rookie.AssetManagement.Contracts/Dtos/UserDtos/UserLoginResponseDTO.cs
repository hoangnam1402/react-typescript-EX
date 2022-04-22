using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.UserDtos
{
    public class UserLoginResponseDTO
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string StaffCode { get; set; }
        public UserLocationEnum Location { get; set; }
        public bool IsConfirmed { get; set; }
        public bool FirstLogin { get; set; }
        public bool IsDisable { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; } 
        
    }
}
