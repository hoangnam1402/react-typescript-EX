using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos
{
    public class AssignmentQueryCriteria : BaseQueryCriteria
    {
        public int[] State { get; set; }
        public DateTime AssignedDate { get; set; }

    }
}
