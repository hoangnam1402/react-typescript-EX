using Microsoft.AspNetCore.Identity;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Rookie.AssetManagement.DataAccessor.Entities
{
    public class User : IdentityUser<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        [Required]
        public UserLocationEnum Location { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string StaffCode { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public UserGenderEnum Gender { get; set; }

        [Required]
        public bool FirstLogin { get; set; } = false;

        [Required]
        public UserTypeEnum Type { get; set; }

        [Required]
        public bool IsDisable { get; set; } = false;

        public User()
        {
            FullName = string.Format("{0} {1}", FirstName, LastName); 
        }
    }
}
