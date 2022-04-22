using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public int AssetID { get; set; }
        public virtual Asset Asset { get; set; }
        public int? AssignByID { get; set; }
        public virtual User AssignBy { get; set; }
        public int? AssignToID { get; set; }
        public virtual User AssignTo { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Note { get; set; }
        public AssignmentStateEnum State { get; set; }
        public UserLocationEnum Location { get; set; }
        public bool IsDelete { get; set; }
    }
}
