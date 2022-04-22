using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public UserLocationEnum Location { get; set; }
        public DateTime JoinDate { get; set; }
        public string StaffCode { get; set; }
        public DateTime DOB { get; set; }
        public UserGenderEnum Gender { get; set; }
        public bool FirstLogin { get; set; }
        public UserTypeEnum Type { get; set; }
        public bool IsDisable { get; set; } = false;
    }



}
