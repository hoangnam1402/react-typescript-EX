using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos
{
    public class AssignmentResponseDTO
    {
        [Required]
        public int AssignmentID { get; set; }
        [Required]
        public AssignmentResponseEnum Response { get; set; } 
    }
}
