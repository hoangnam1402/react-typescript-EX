using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos
{
    public class AssignmentDTO
    {
        public int Id { get; set; }
        public int AssetID { get; set; }
        public virtual AssetDTO Asset { get; set; }
        public int? AssignByID { get; set; }
        public virtual UserDto AssignBy { get; set; }
        public int? AssignToID { get; set; }
        public virtual UserDto AssignTo { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Note { get; set; }
        public AssignmentStateEnum State { get; set; }
        public UserLocationEnum Location { get; set; }
        public bool IsDelete { get; set; }
    }
}
