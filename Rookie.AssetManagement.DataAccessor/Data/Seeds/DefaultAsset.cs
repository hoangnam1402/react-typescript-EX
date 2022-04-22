using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.DataAccessor.Data.Seeds
{
    public class DefaultAsset : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasData(
             //Laptop
             new Asset()
             {
                 Id = 1,
                 Name = "Laptop HP Pro Book 450 G1",
                 CategoryID = 1,
                 Code = "LA000001",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Laptop",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,
             },
             new Asset()
             {
                 Id = 2,
                 Name = "Laptop HP Pro Book 450 G1",
                 CategoryID = 1,
                 Code = "LA000002",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Laptop",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 3,
                 Name = "Laptop HP Pro Book 450 G1",
                 CategoryID = 1,
                 Code = "LA000003",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Laptop",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 4,
                 Name = "Laptop HP Pro Book 450 G1",
                 CategoryID = 1,
                 Code = "LA000004",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Laptop",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 5,
                 Name = "Laptop HP Pro Book 450 G1",
                 CategoryID = 1,
                 Code = "LA000005",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of Laptop",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             //Monitor
             new Asset()
             {
                 Id = 6,
                 Name = "Monitor Dell UltraSharp",
                 CategoryID = 2,
                 Code = "MO000001",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Monitor",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 7,
                 Name = "Monitor Dell UltraSharp",
                 CategoryID = 2,
                 Code = "MO000002",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Monitor",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 8,
                 Name = "Monitor Dell UltraSharp",
                 CategoryID = 2,
                 Code = "MO000003",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Monitor",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 9,
                 Name = "Monitor Dell UltraSharp",
                 CategoryID = 2,
                 Code = "MO000004",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of Monitor",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 10,
                 Name = "Monitor Dell UltraSharp",
                 CategoryID = 2,
                 Code = "MO000005",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of Monitor",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 11,
                 Name = "Monitor Dell UltraSharp",
                 CategoryID = 2,
                 Code = "MO000006",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of Monitor",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             //PC
             new Asset()
             {
                 Id = 12,
                 Name = "Personal Computer",
                 CategoryID = 3,
                 Code = "PC000001",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of PC",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 13,
                 Name = "Personal Computer",
                 CategoryID = 3,
                 Code = "PC000002",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of PC",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 14,
                 Name = "Personal Computer",
                 CategoryID = 3,
                 Code = "PC000003",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of PC",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 15,
                 Name = "Personal Computer",
                 CategoryID = 3,
                 Code = "PC000004",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of PC",
                 State = (Enums.AssetStateEnum)1,
                 IsDeleted = false,

             },
              //Assigned Laptop
              new Asset()
              {
                  Id = 16,
                  Name = "Laptop HP Pro Book 450 G1",
                  CategoryID = 1,
                  Code = "LA000006",
                  InstallDate = DateTime.Now.AddDays(365),
                  LastUpdate = DateTime.Now,
                  Location = (Enums.UserLocationEnum)1,
                  Specification = "Specification of Laptop",
                  State = (Enums.AssetStateEnum)2,
                  IsDeleted = false,

              },
             new Asset()
             {
                 Id = 17,
                 Name = "Laptop HP Pro Book 450 G1",
                 CategoryID = 1,
                 Code = "LA000007",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Laptop",
                 State = (Enums.AssetStateEnum)2,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 18,
                 Name = "Laptop HP Pro Book 450 G1",
                 CategoryID = 1,
                 Code = "LA000008",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Laptop",
                 State = (Enums.AssetStateEnum)3,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 19,
                 Name = "Laptop HP Pro Book 450 G1",
                 CategoryID = 1,
                 Code = "LA000009",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of Laptop",
                 State = (Enums.AssetStateEnum)2,
                 IsDeleted = false,

             },
               //Assigned Monitor
               new Asset()
               {
                   Id = 20,
                   Name = "Monitor Dell UltraSharp",
                   CategoryID = 2,
                   Code = "MO000007",
                   InstallDate = DateTime.Now.AddDays(365),
                   LastUpdate = DateTime.Now,
                   Location = (Enums.UserLocationEnum)1,
                   Specification = "Specification of Monitor",
                   State = (Enums.AssetStateEnum)3,
                   IsDeleted = false,

               },
             new Asset()
             {
                 Id = 21,
                 Name = "Monitor Dell UltraSharp",
                 CategoryID = 2,
                 Code = "MO000008",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of Monitor",
                 State = (Enums.AssetStateEnum)2,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 22,
                 Name = "Monitor Dell UltraSharp",
                 CategoryID = 2,
                 Code = "MO000009",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of Monitor",
                 State = (Enums.AssetStateEnum)2,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 23,
                 Name = "Monitor Dell UltraSharp",
                 CategoryID = 2,
                 Code = "MO000010",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of Monitor",
                 State = (Enums.AssetStateEnum)3,
                 IsDeleted = false,

             },
             //Assigned PC
              new Asset()
              {
                  Id = 24,
                  Name = "Personal Computer",
                  CategoryID = 3,
                  Code = "PC000005",
                  InstallDate = DateTime.Now.AddDays(365),
                  LastUpdate = DateTime.Now,
                  Location = (Enums.UserLocationEnum)1,
                  Specification = "Specification of PC",
                  State = (Enums.AssetStateEnum)3,
                  IsDeleted = false,

              },
             new Asset()
             {
                 Id = 25,
                 Name = "Personal Computer",
                 CategoryID = 3,
                 Code = "PC000006",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)1,
                 Specification = "Specification of PC",
                 State = (Enums.AssetStateEnum)3,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 26,
                 Name = "Personal Computer",
                 CategoryID = 3,
                 Code = "PC000007",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of PC",
                 State = (Enums.AssetStateEnum)3,
                 IsDeleted = false,

             },
             new Asset()
             {
                 Id = 27,
                 Name = "Personal Computer",
                 CategoryID = 3,
                 Code = "PC000008",
                 InstallDate = DateTime.Now.AddDays(365),
                 LastUpdate = DateTime.Now,
                 Location = (Enums.UserLocationEnum)2,
                 Specification = "Specification of PC",
                 State = (Enums.AssetStateEnum)2,
                 IsDeleted = false,

             }
            );
        }
    }
}
