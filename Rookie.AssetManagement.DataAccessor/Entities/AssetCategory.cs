﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Entities
{
    public class AssetCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList<Asset> Assets { get; set; }


        public AssetCategory()
        {
            Assets = new List<Asset>();
        }
    }
}
