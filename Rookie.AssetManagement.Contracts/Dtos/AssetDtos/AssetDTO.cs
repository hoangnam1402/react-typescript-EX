using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.AssetDtos
{
    public class AssetDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public DateTime InstallDate { get; set; }
        public AssetStateEnum State { get; set; }
        public int CategoryID { get; set; }
        public AssetCategoryDTO Category { get; set; }
        public DateTime LastUpdate { get; set; }
        public UserLocationEnum Location { get; set; }

    }
}
