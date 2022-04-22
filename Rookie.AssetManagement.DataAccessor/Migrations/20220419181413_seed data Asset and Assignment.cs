using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class seeddataAssetandAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AssetCategories",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 1, "Laptop", "LA" });

            migrationBuilder.InsertData(
                table: "AssetCategories",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 2, "Monitor", "MO" });

            migrationBuilder.InsertData(
                table: "AssetCategories",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 3, "Personal Computer", "PC" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "CategoryID", "Code", "InstallDate", "IsDeleted", "LastUpdate", "Location", "Name", "Specification", "State" },
                values: new object[,]
                {
                    { 1, 1, "LA000001", new DateTime(2023, 4, 20, 1, 14, 12, 458, DateTimeKind.Local).AddTicks(7261), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(4558), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 25, 3, "PC000006", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8493), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8495), 1, "Personal Computer", "Specification of PC", 3 },
                    { 24, 3, "PC000005", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8486), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8489), 1, "Personal Computer", "Specification of PC", 3 },
                    { 15, 3, "PC000004", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8423), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8426), 2, "Personal Computer", "Specification of PC", 1 },
                    { 14, 3, "PC000003", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8416), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8419), 2, "Personal Computer", "Specification of PC", 1 },
                    { 13, 3, "PC000002", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8409), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8412), 1, "Personal Computer", "Specification of PC", 1 },
                    { 12, 3, "PC000001", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8403), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8406), 1, "Personal Computer", "Specification of PC", 1 },
                    { 23, 2, "MO000010", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8478), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8481), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 3 },
                    { 22, 2, "MO000009", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8472), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8475), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 2 },
                    { 21, 2, "MO000008", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8465), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8468), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 2 },
                    { 20, 2, "MO000007", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8458), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8461), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 3 },
                    { 11, 2, "MO000006", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8396), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8399), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 26, 3, "PC000007", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8499), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8502), 2, "Personal Computer", "Specification of PC", 3 },
                    { 10, 2, "MO000005", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8387), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8391), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 8, 2, "MO000003", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8374), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8376), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 7, 2, "MO000002", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8365), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8369), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 6, 2, "MO000001", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8359), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8361), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 19, 1, "LA000009", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8452), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8454), 2, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 },
                    { 18, 1, "LA000008", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8445), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8448), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 3 },
                    { 17, 1, "LA000007", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8438), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8441), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 },
                    { 16, 1, "LA000006", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8430), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8433), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 },
                    { 5, 1, "LA000005", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8352), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8354), 2, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 4, 1, "LA000004", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8345), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8348), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 3, 1, "LA000003", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8337), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8341), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 2, 1, "LA000002", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8299), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8330), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 9, 2, "MO000004", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8380), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8383), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 27, 3, "PC000008", new DateTime(2023, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8507), false, new DateTime(2022, 4, 20, 1, 14, 12, 460, DateTimeKind.Local).AddTicks(8509), 2, "Personal Computer", "Specification of PC", 2 }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssetID", "AssignByID", "AssignDate", "AssignToID", "IsDelete", "Location", "Note", "ReturnDate", "State" },
                values: new object[,]
                {
                    { 1, 16, 4, new DateTime(2022, 4, 20, 1, 14, 12, 463, DateTimeKind.Local).AddTicks(7613), 14, false, 1, "Assign asset to this staff.", null, 1 },
                    { 2, 17, 4, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3070), 15, false, 1, "Assign asset to this staff.", null, 1 },
                    { 3, 18, 4, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3094), 16, false, 1, "Assign asset to this staff.", null, 2 },
                    { 4, 19, 6, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3106), 8, false, 2, "Assign asset to this staff.", null, 1 },
                    { 5, 20, 4, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3112), 17, false, 1, "Assign asset to this staff.", null, 2 },
                    { 6, 21, 6, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3119), 9, false, 2, "Assign asset to this staff.", null, 1 },
                    { 7, 22, 6, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3125), 10, false, 2, "Assign asset to this staff.", null, 1 },
                    { 8, 23, 4, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3131), 14, false, 1, "Assign asset to this staff.", null, 2 },
                    { 9, 24, 4, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3137), 14, false, 1, "Assign asset to this staff.", null, 2 },
                    { 10, 25, 6, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3146), 11, false, 2, "Assign asset to this staff.", null, 2 },
                    { 11, 26, 6, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3153), 12, false, 2, "Assign asset to this staff.", null, 2 },
                    { 12, 27, 4, new DateTime(2022, 4, 20, 1, 14, 12, 464, DateTimeKind.Local).AddTicks(3158), 12, false, 2, "Assign asset to this staff.", null, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AssetCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssetCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssetCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
