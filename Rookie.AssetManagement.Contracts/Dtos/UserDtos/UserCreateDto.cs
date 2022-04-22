using System;
using System.ComponentModel.DataAnnotations;
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.Contracts.Dtos.UserDtos
{
    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime DOB { get; set; }
        public UserGenderEnum Gender { get; set; }
        public UserTypeEnum Type{get;set;}
        
    }
}
