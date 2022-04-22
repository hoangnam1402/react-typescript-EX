using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Data.Seeds
{
    public class DefaultAssetCategory : IEntityTypeConfiguration<AssetCategory>
    {
        public void Configure(EntityTypeBuilder<AssetCategory> builder)
        {
            builder.HasData(
                new AssetCategory() { Id = 1, Name = "Laptop", ShortName = "LA" },
                new AssetCategory() { Id = 2, Name = "Monitor", ShortName = "MO" },
                new AssetCategory() { Id = 3, Name = "Personal Computer", ShortName = "PC" }
            );
        }
    }
}
