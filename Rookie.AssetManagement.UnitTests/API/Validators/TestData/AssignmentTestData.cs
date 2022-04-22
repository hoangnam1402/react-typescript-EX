using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.UnitTests.API.Validators.TestData
{
    public static class AssignmentTestData
    {

        public static List<Assignment> GetAssignments()
        {
            var list = new List<Assignment>()
            {

                new Assignment()
                {
                    Id = 0,
                    AssetID = 27,
                    AssignToID = 2,
                    Note = "Assign asset to this staff.",
                },
                new Assignment()
                {
                    Id = 1,
                    AssetID = 16,
                    Asset = new Asset()
                    {
                         Id = 16,
                         Name = "Personal Computer",
                         CategoryID = 1,
                         Code = "PC000005",
                         InstallDate = DateTime.Now.AddDays(365),
                         LastUpdate = DateTime.Now,
                         Location = DataAccessor.Enums.UserLocationEnum.HCM,
                         Specification = "Specification of Monitor",
                         State = DataAccessor.Enums.AssetStateEnum.Available,
                    },
                    AssignByID = 4,
                    AssignToID = 14,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                },
                new Assignment()
                {
                    Id = 2,
                    AssetID = 17,
                    AssignByID = 4,
                    AssignToID = 15,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = DataAccessor.Enums.UserLocationEnum.HCM
                },
                new Assignment()
                {
                    Id = 3,
                    AssetID = 18,
                    AssignByID = 4,
                    AssignToID = 1,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.Accepted,
                    Location = DataAccessor.Enums.UserLocationEnum.HCM
                },
                new Assignment()
                {
                    Id = 4,
                    AssetID = 19,
                    AssignByID = 6,
                    AssignToID = 1,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.Accepted,
                    Location = DataAccessor.Enums.UserLocationEnum.HN
                },
                new Assignment()
                {
                    Id = 5,
                    AssetID = 20,
                    AssignByID = 4,
                    AssignToID = 17,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.Accepted,
                    Location = DataAccessor.Enums.UserLocationEnum.HCM
                },
                new Assignment()
                {
                    Id = 6,
                    AssetID = 21,
                    AssignByID = 6,
                    AssignToID = 9,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = DataAccessor.Enums.UserLocationEnum.HN
                },
                new Assignment()
                {
                    Id = 7,
                    AssetID = 22,
                    AssignByID = 6,
                    AssignToID = 10,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = DataAccessor.Enums.UserLocationEnum.HN
                },
                new Assignment()
                {
                    Id = 8,
                    AssetID = 23,
                    AssignByID = 4,
                    AssignToID = 14,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.Accepted,
                    Location = DataAccessor.Enums.UserLocationEnum.HCM
                },
                new Assignment()
                {
                    Id = 9,
                    AssetID = 24,
                    AssignByID = 4,
                    AssignToID = 14,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.Accepted,
                    Location = DataAccessor.Enums.UserLocationEnum.HCM
                },
                new Assignment()
                {
                    Id = 10,
                    AssetID = 25,
                    AssignByID = 6,
                    AssignToID = 11,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.Accepted,
                    Location = DataAccessor.Enums.UserLocationEnum.HN
                },
                new Assignment()
                {
                    Id = 11,
                    AssetID = 26,
                    AssignByID = 6,
                    AssignToID = 12,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.Accepted,
                    Location = DataAccessor.Enums.UserLocationEnum.HN
                },
                new Assignment()
                {
                    Id = 12,
                    AssetID = 27,
                    AssignByID = 4,
                    AssignToID = 12,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = DataAccessor.Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = DataAccessor.Enums.UserLocationEnum.HN
                }
            };

            return list;
        }
        public static Assignment GetCreateAssignment()
        {
            return new Assignment()
            {
                AssetID = 27,
                AssignToID = 2,
                AssignDate = Convert.ToDateTime("08/29/2022"),
                Note = "Assign asset to this staff.",
            };
        }

        public static AssignmentCreateDTO GetCreateAssignmentDto()
        {
            return new AssignmentCreateDTO()
            {
                AssetID = 27,
                AssignToID = 2,
                AssignDate = Convert.ToDateTime("08/29/2022"),
                Note = "Assign asset to this staff.",
            };
        }

        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User() { Id = 1, FirstName = "First", LastName = "LA", Location = DataAccessor.Enums.UserLocationEnum.HCM },
                new User() { Id = 2, FirstName = "Second", LastName = "MO", Location = DataAccessor.Enums.UserLocationEnum.HCM },
                new User() { Id = 3, FirstName = "Third", LastName = "PC", Location = DataAccessor.Enums.UserLocationEnum.HN }
            };

        }

        public static List<Asset> GetAssets()
        {
            var list = new List<Asset>()
            {
                 new Asset() {
                     Id= 17,
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
                     Id = 27,
                     Name = "Laptop HP Pro Book 450 G1",
                     CategoryID = 1,
                     Code = "LA000002",
                     InstallDate = DateTime.Now.AddDays(365),
                     LastUpdate = DateTime.Now,
                     Location = (DataAccessor.Enums.UserLocationEnum)1,
                     Specification = "Specification of Laptop",
                     State = (DataAccessor.Enums.AssetStateEnum)1,
                 },
            };
            return list;
        }
        public static IEnumerable<object[]> ValidAssignmentResponseDTO()
        {
            return new object[][]
            {
                new object[]
                {
                    18,
                    0,
                },
            };
        }
        public static IEnumerable<object[]> InvalidAssignmentID()
        {
            var x = new AssignmentResponseDTO();
            return new object[][]
            {
                new object[]
                {
                    null,
                    string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignmentID)),
                },
            };
        }
        public static IEnumerable<object[]> ValidResponse()
        {
            var x = new AssignmentResponseDTO();
            return new object[][]
            {
                new object[]
                {
                    1,
                },
            };
        }
    }
}
