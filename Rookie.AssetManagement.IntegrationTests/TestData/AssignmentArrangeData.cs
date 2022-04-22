using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public class AssignmentArrangeData
    {
        public static void InitAssetData(ApplicationDbContext dbContext)
        {
            var assets = GetAssets();
            var category = GetAssetCategories();
           
            dbContext.AssetCategories.AddRange(category);
            dbContext.Assets.AddRange(assets);

            dbContext.SaveChanges();
        }

        public static void InitAssignmentData(ApplicationDbContext dbContext)
        {
            var assignments = GetAssignments();
            dbContext.Assignments.AddRange(assignments);
            dbContext.SaveChanges();
        }

        public static void InitUserData(ApplicationDbContext dbContext)
        {
            User userHCM = new User
            {
                Id = 1,
                StaffCode = "SD0001",
                UserName = "adminhcm",
                FirstName = "FirstName",
                LastName = "LassName",
                Location = (DataAccessor.Enums.UserLocationEnum)1,
                JoinDate = DateTime.Now,
                Gender = (DataAccessor.Enums.UserGenderEnum)1,
                DOB = DateTime.Parse("01-01-2000"),
                Email = "adminhcm@gmail.com",
                EmailConfirmed = true,
                FirstLogin = true,
                Type = (DataAccessor.Enums.UserTypeEnum)1,
                IsDisable = false
            };
            User staffHCM = new User
            {
                Id = 3,
                StaffCode = "SD0003",
                UserName = "staffhcm",
                FirstName = "FirstName",
                LastName = "LassName",
                Location = (DataAccessor.Enums.UserLocationEnum)1,
                JoinDate = DateTime.Now,
                Gender = (DataAccessor.Enums.UserGenderEnum)1,
                DOB = DateTime.Parse("01-01-2000"),
                Email = "staffhcm@gmail.com",
                EmailConfirmed = true,
                FirstLogin = true,
                Type = (DataAccessor.Enums.UserTypeEnum)2,
                IsDisable = false
            };
            User userHN = new User
            {
                Id = 2,
                StaffCode = "SD0001",
                UserName = "adminhcm",
                FirstName = "FirstName",
                LastName = "LassName",
                Location = (DataAccessor.Enums.UserLocationEnum)2,
                JoinDate = DateTime.Now,
                Gender = (DataAccessor.Enums.UserGenderEnum)1,
                DOB = DateTime.Parse("01-01-2000"),
                Email = "adminhcm@gmail.com",
                EmailConfirmed = true,
                FirstLogin = true,
                Type = (DataAccessor.Enums.UserTypeEnum)1,
                IsDisable = false
            };
            User staffHN = new User
            {
                Id = 4,
                StaffCode = "SD0004",
                UserName = "staffhn",
                FirstName = "FirstName",
                LastName = "LassName",
                Location = (DataAccessor.Enums.UserLocationEnum)1,
                JoinDate = DateTime.Now,
                Gender = (DataAccessor.Enums.UserGenderEnum)1,
                DOB = DateTime.Parse("01-01-2000"),
                Email = "staffhn@gmail.com",
                EmailConfirmed = true,
                FirstLogin = true,
                Type = (DataAccessor.Enums.UserTypeEnum)2,
                IsDisable = false
            };
            dbContext.Users.Add(userHCM);
            dbContext.SaveChanges();
            dbContext.Users.Add(userHN);
            dbContext.SaveChanges();
            dbContext.Users.Add(staffHCM);
            dbContext.SaveChanges();
            dbContext.Users.Add(staffHN);
            dbContext.SaveChanges();
        }

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
                     Location = (DataAccessor.Enums.UserLocationEnum)2,
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
                     Location = (DataAccessor.Enums.UserLocationEnum)2,
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
                 }
            };
            return assets;
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

        public static List<Assignment> GetAssignments()
        {
            var list = new List<Assignment>()
            {
                 new Assignment()
                {
                    Id = 1,
                    AssetID = 1,
                    AssignByID = 1,
                    AssignToID = 3,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = DataAccessor.Enums.UserLocationEnum.HCM
                },
                new Assignment()
                {
                    Id = 2,
                    AssetID = 2,
                    AssignByID = 1,
                    AssignToID = 1,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = DataAccessor.Enums.UserLocationEnum.HCM
                },
                new Assignment()
                {
                    Id = 3,
                    AssetID = 3,
                    AssignByID = 1,
                    AssignToID = 1,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.Accepted,
                    Location = DataAccessor.Enums.UserLocationEnum.HCM
                },
                new Assignment()
                {
                    Id = 4,
                    AssetID = 4,
                    AssignByID = 2,
                    AssignToID = 4,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = DataAccessor.Enums.UserLocationEnum.HN
                },
                new Assignment()
                {
                    Id = 5,
                    AssetID = 5,
                    AssignByID = 1,
                    AssignToID = 3,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.Accepted,
                    Location = DataAccessor.Enums.UserLocationEnum.HCM
                },
                new Assignment()
                {
                    Id = 6,
                    AssetID = 6,
                    AssignByID = 2,
                    AssignToID = 4,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = DataAccessor.Enums.UserLocationEnum.HN
                },
            };

            return list;
        }

        public static AssignmentCreateDTO GetCreateNewAssignmentDto()
        {
            return new AssignmentCreateDTO()
            {
                AssetID = 15,
                AssignToID = 1,
                AssignDate = Convert.ToDateTime("08/29/2022"),
                Note = "Assign asset to this staff.",
            };
        }

        public static AssignmentCreateDTO GetInValidCreateNewAssignmentDto()
        {
            return new AssignmentCreateDTO()
            {
                AssetID = 15,
                AssignToID = 0,
                AssignDate = Convert.ToDateTime("08/29/2022"),
                Note = "",
            };
        }
    }
}
