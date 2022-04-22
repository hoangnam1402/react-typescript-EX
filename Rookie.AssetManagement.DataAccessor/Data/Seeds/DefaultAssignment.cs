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
    public class DefaultAssignment : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasData(
                new Assignment()
                {
                    Id = 1,
                    AssetID = 16,
                    AssignByID = 4,
                    AssignToID = 14,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = Enums.UserLocationEnum.HCM,
                    IsDelete = false,
                },
                new Assignment()
                {
                    Id = 2,
                    AssetID = 17,
                    AssignByID = 4,
                    AssignToID = 15,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = Enums.UserLocationEnum.HCM,
                    IsDelete = false,

                },
                new Assignment()
                {
                    Id = 3,
                    AssetID = 18,
                    AssignByID = 4,
                    AssignToID = 16,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.Accepted,
                    Location = Enums.UserLocationEnum.HCM,
                    IsDelete = false,

                },
                new Assignment()
                {
                    Id = 4,
                    AssetID = 19,
                    AssignByID = 6,
                    AssignToID = 8,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = Enums.UserLocationEnum.HN,
                    IsDelete = false,

                },
                new Assignment()
                {
                    Id = 5,
                    AssetID = 20,
                    AssignByID = 4,
                    AssignToID = 17,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.Accepted,
                    Location = Enums.UserLocationEnum.HCM,
                    IsDelete = false,

                },
                new Assignment()
                {
                    Id = 6,
                    AssetID = 21,
                    AssignByID = 6,
                    AssignToID = 9,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = Enums.UserLocationEnum.HN,
                    IsDelete = false,

                },
                new Assignment()
                {
                    Id = 7,
                    AssetID = 22,
                    AssignByID = 6,
                    AssignToID = 10,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = Enums.UserLocationEnum.HN,
                    IsDelete = false,
                },
                new Assignment()
                {
                    Id = 8,
                    AssetID = 23,
                    AssignByID = 4,
                    AssignToID = 14,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.Accepted,
                    Location = Enums.UserLocationEnum.HCM,
                    IsDelete = false,

                },
                new Assignment()
                {
                    Id = 9,
                    AssetID = 24,
                    AssignByID = 4,
                    AssignToID = 14,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.Accepted,
                    Location = Enums.UserLocationEnum.HCM,
                    IsDelete = false,

                },
                new Assignment()
                {
                    Id = 10,
                    AssetID = 25,
                    AssignByID = 6,
                    AssignToID = 11,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.Accepted,
                    Location = Enums.UserLocationEnum.HN,
                    IsDelete = false,

                },
                new Assignment()
                {
                    Id = 11,
                    AssetID = 26,
                    AssignByID = 6,
                    AssignToID = 12,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.Accepted,
                    Location = Enums.UserLocationEnum.HN,
                    IsDelete = false,

                },
                new Assignment()
                {
                    Id = 12,
                    AssetID = 27,
                    AssignByID = 4,
                    AssignToID = 12,
                    AssignDate = DateTime.Now,
                    Note = "Assign asset to this staff.",
                    State = Enums.AssignmentStateEnum.WaitingForAcceptance,
                    Location = Enums.UserLocationEnum.HN,
                    IsDelete = false,

                }
            );
        }
    }
}
