using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.Contracts.Dtos.AssetDtos
{
    public class AssetCreateDTO
    {
        public string Name { get; set; }
        public string Specification { get; set; }
        public DateTime InstallDate { get; set; }
        public AssetStateEnum State { get; set; }
        public int CategoryID { get; set; }

    }
}
