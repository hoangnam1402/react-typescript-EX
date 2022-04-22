using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
namespace Rookie.AssetManagement.UnitTests.API.Validators.TestData
{
    public static class AssetTestData
    {
        public static List<Asset> GetAssets()
        {
            var assets = new List<Asset>()
            {
                 new Asset() {
                     Id=1,
                     Name="Laptop HP Pro Book 450 G1",
                     CategoryID =1,
                     Code="LA000001",
                     InstallDate=DateTime.Now.AddDays(365),
                     LastUpdate=DateTime.Now,
                     Location= (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of Laptop",
                     State=(DataAccessor.Enums.AssetStateEnum)1,
                 },
                 new Asset()
                 {
                     Id = 2,
                     Name = "Laptop HP Pro Book 450 G1",
                     CategoryID = 1,
                     Code = "LA000002",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of Laptop",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
                 },
                 new Asset()
                 {
                     Id = 3,
                     Name = "Laptop HP Pro Book 450 G1",
                     CategoryID = 1,
                     Code = "LA000003",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of Laptop",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
                 },
                 new Asset()
                 {
                     Id = 4,
                     Name = "Laptop HP Pro Book 450 G1",
                     CategoryID = 1,
                     Code = "LA000004",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of Laptop",
                     State = (DataAccessor.Enums.AssetStateEnum)2,
                 },
                 new Asset()
                 {
                     Id = 5,
                     Name = "Laptop HP Pro Book 450 G1",
                     CategoryID = 1,
                     Code = "LA000005",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)2,
                     Specification = "Specification of Laptop",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
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
                     Location = (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of Monitor",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
                 },
                 new Asset()
                 {
                     Id = 7,
                     Name = "Monitor Dell UltraSharp",
                     CategoryID = 2,
                     Code = "MO000002",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of Monitor",
                     State = (DataAccessor.Enums.AssetStateEnum)2,
                 },
                 new Asset()
                 {
                     Id = 8,
                     Name = "Monitor Dell UltraSharp",
                     CategoryID = 2,
                     Code = "MO000003",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of Monitor",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
                 },
                 new Asset()
                 {
                     Id = 9,
                     Name = "Monitor Dell UltraSharp",
                     CategoryID = 2,
                     Code = "MO000004",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)2,
                     Specification = "Specification of Monitor",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
                 },
                 new Asset()
                 {
                     Id = 10,
                     Name = "Monitor Dell UltraSharp",
                     CategoryID = 2,
                     Code = "MO000005",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)2,
                     Specification = "Specification of Monitor",
                     State = (DataAccessor.Enums.AssetStateEnum)2,
                 },
                 new Asset()
                 {
                     Id = 11,
                     Name = "Monitor Dell UltraSharp",
                     CategoryID = 2,
                     Code = "MO000006",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)2,
                     Specification = "Specification of Monitor",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
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
                     Location = (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of PC",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
                 },
                 new Asset()
                 {
                     Id = 13,
                     Name = "Personal Computer",
                     CategoryID = 3,
                     Code = "PC000002",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of PC",
                     State = (DataAccessor.Enums.AssetStateEnum)2,
                 },
                 new Asset()
                 {
                     Id = 14,
                     Name = "Personal Computer",
                     CategoryID = 3,
                     Code = "PC000003",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)2,
                     Specification = "Specification of PC",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
                 },
                 new Asset()
                 {
                     Id = 15,
                     Name = "Personal Computer",
                     CategoryID = 3,
                     Code = "PC000004",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)2,
                     Specification = "Specification of PC",
                     State = (DataAccessor.Enums.AssetStateEnum)2,
                 },
                 new Asset()
                 {
                     Id = 16,
                     Name = "Personal Computer",
                     CategoryID = 1,
                     Code = "PC000005",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)2,
                     Specification = "Specification of Monitor",
                     State = (DataAccessor.Enums.AssetStateEnum)3,
                 }
            };
            return assets;
        }

        public static Asset GetAsset()
        {
            return new Asset()
            {
                Name = "Personal Computer",
                CategoryID = 1,
                Code = "PC000001",
                InstallDate = Convert.ToDateTime("1/5/2000"),
                LastUpdate = Convert.ToDateTime("12/5/2000"),
                Location = UserLocationEnum.HCM,
                Specification = "Specification of PC",
                State = AssetStateEnum.Available,
            };
        }

        public static List<AssetCategory> GetAssetCategories()
        {
            return new List<AssetCategory>()
            {
                new AssetCategory() { Id = 1, Name = "Laptop", ShortName = "LA" },
                new AssetCategory() { Id = 2, Name = "Monitor", ShortName = "MO" },
                new AssetCategory() { Id = 3, Name = "Personal Computer", ShortName = "PC" }
            };

        }
        public static AssetQueryCriteria GetAssetQueryCriteriaDto()
        {
            return new AssetQueryCriteria()
            {
                Limit = 5,
                Page = 1
            };
        }

        public static IEnumerable<object[]> ValidName()
        {
            return new object[][]
            {
                new object[] { "Laptop HP Pro Book 450 G1" },
                new object[] { "Personal Computer" },
                new object[] { "Monitor Dell UltraSharp" },
            };
        }

        public static IEnumerable<object[]> IsEmptyName()
        {
            return new object[][]
            {
                new object[] {
                    "" ,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(AssetCreateDTO.Name), 0),
                },
            };
        }

        public static IEnumerable<object[]> IsNullName()
        {
            return new object[][]{
                new object[]
                {
                    null,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(AssetCreateDTO.Name), 0),
                },
            };
        }

        public static IEnumerable<object[]> ValidSpecification()
        {
            return new object[][]
            {
                new object[] { "Specification of PC" },
                new object[] { "Specification of Monitor" },
                new object[] { "Specification of Laptop" },
            };
        }

        public static IEnumerable<object[]> IsEmptySpecification()
        {
            return new object[][]
            {
                new object[] {
                    "" ,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(AssetCreateDTO.Specification), 0),
                },
            };
        }

        public static IEnumerable<object[]> IsNullSpecification()
        {
            return new object[][]{
                new object[]
                {
                    null,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(AssetCreateDTO.Specification), 0),
                },
            };
        }

        public static IEnumerable<object[]> ValidInstallDate()
        {
            return new object[][]
            {
                new object[] { Convert.ToDateTime("12/5/2020") },
                new object[] { Convert.ToDateTime("2/14/2000") },
            };
        }

        public static IEnumerable<object[]> ValidState()
        {
            return new object[][]
            {
                new object[] {
                    AssetStateEnum.Available
                },
                new object[] {
                    AssetStateEnum.NotAvailable
                },
            };
        }

        public static IEnumerable<object[]> ValidCategoryID()
        {
            return new object[][]
            {
                new object[] { 1 },
                new object[] { 2 },
            };
        }

        public static AssetCreateDTO GetCreateAssetDto()
        {
            return new AssetCreateDTO()
            {
                Name = "Personal Computer",
                Specification = "Specification of Monitor",
                InstallDate = Convert.ToDateTime("03/30/2022"),
                State = AssetStateEnum.Assigned,
                CategoryID = 1
            };
        }

        public static Asset GetCreateAsset()
        {
            return new Asset()
            {
                Name = "Personal Computer",
                Specification = "Specification of Monitor",
                InstallDate = Convert.ToDateTime("03/30/2022"),
                State = AssetStateEnum.Assigned,
                CategoryID = 1
            };
        }

        public static AssetCreateDTO GetInValidCreateNewAssetDto()
        {
            return new AssetCreateDTO()
            {
                Name = "",
                Specification = "Specification of Monitor",
                InstallDate = Convert.ToDateTime("03/30/2022"),
                State = AssetStateEnum.Assigned,
                CategoryID = 1
            };
        }
        public static int UnExistedAssetId = 20;
        public static int ExistedAssetId = 15;
        public static Asset GetUpdatedAsset(int id)
        {
            return new Asset()
            {
                Id = id,
                Name = "Personal Computer",
                CategoryID = 3,
                Code = "PC000004",
                InstallDate = DateTime.Now.AddDays(365),
                LastUpdate = DateTime.Now,
                Location = (DataAccessor.Enums.UserLocationEnum)2,
                Specification = "Specification of PC",
                State = (DataAccessor.Enums.AssetStateEnum)2,
            };
        }
        public static AssetUpdateDTO GetUpdateAssetDto()
        {
            return new AssetUpdateDTO()
            {
                Name = "Personal Computer Updated",
                InstallDate = DateTime.Parse("04/10/2022"),
                Specification = "Specification of Personal Computer",
                State = (DataAccessor.Enums.AssetStateEnum)1,
            };
        }

        public static Asset GetUpdateAsset()
        {
            var updatedAsset = GetUpdatedAsset(ExistedAssetId);
            updatedAsset.Name = "Personal Computer Updated";
            updatedAsset.InstallDate = DateTime.Parse("04/10/2022");
            updatedAsset.Specification = "Specification of Personal Computer";
            updatedAsset.State = (DataAccessor.Enums.AssetStateEnum)1;

            return updatedAsset;
        }


        public static Asset GetAsset(int id)
        {
            return new Asset()
            {
                Id = id,
                Name = "Personal Computer",
                CategoryID = 1,
                Code = "PC000001",
                InstallDate = DateTime.Now.AddDays(365),
                LastUpdate = DateTime.Now,
                Location = (DataAccessor.Enums.UserLocationEnum)2,
                Specification = "Specification of Monitor",
                State = (DataAccessor.Enums.AssetStateEnum)2,
            };
        }


        public static Asset GetAsset1()
        {
            return new Asset()
            {
                Id = 1,
                Name = "Personal Computer",
                CategoryID = 1,
                Code = "PC000001",
                InstallDate = DateTime.Now.AddDays(365),
                LastUpdate = DateTime.Now,
                Location = (DataAccessor.Enums.UserLocationEnum)2,
                Specification = "Specification of Monitor",
                State = (DataAccessor.Enums.AssetStateEnum)3,
            };
        }
    }
}
