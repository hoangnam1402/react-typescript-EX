using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.AssetDtos
{
    public class AssetQueryCriteria : BaseQueryCriteria
    {
        public int[] Category { get; set; }
        public int[] State { get; set; }

    }
}
