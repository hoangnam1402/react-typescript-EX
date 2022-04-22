using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.UserDtos
{
    public class UserLoginDTO
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(1)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(1)]
        public string Password { get; set; }
    }
}
