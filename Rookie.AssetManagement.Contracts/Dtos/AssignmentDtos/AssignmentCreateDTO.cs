using System;

namespace Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos
{
    public class AssignmentCreateDTO
    {
        public int AssetID { get; set; }
        public int AssignToID { get; set; }
        public DateTime AssignDate { get; set; }
        public string Note { get; set; }
    }
}
