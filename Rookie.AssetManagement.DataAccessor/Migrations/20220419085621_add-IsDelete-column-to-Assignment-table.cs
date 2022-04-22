using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class addIsDeletecolumntoAssignmenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Assignments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Assignments");

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
                    { 1, 1, "LA000001", new DateTime(2023, 4, 12, 15, 54, 45, 726, DateTimeKind.Local).AddTicks(3942), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(1060), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 25, 3, "PC000006", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2114), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2115), 1, "Personal Computer", "Specification of PC", 3 },
                    { 24, 3, "PC000005", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2112), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2113), 1, "Personal Computer", "Specification of PC", 3 },
                    { 15, 3, "PC000004", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2038), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2039), 2, "Personal Computer", "Specification of PC", 1 },
                    { 14, 3, "PC000003", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2036), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2037), 2, "Personal Computer", "Specification of PC", 1 },
                    { 13, 3, "PC000002", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2034), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2035), 1, "Personal Computer", "Specification of PC", 1 },
                    { 12, 3, "PC000001", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2032), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2033), 1, "Personal Computer", "Specification of PC", 1 },
                    { 23, 2, "MO0000010", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2110), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2111), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 3 },
                    { 22, 2, "MO000009", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2108), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2109), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 2 },
                    { 21, 2, "MO000008", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2106), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2107), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 2 },
                    { 20, 2, "MO000007", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2104), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2105), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 3 },
                    { 11, 2, "MO000006", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2030), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2031), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 26, 3, "PC000007", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2116), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2117), 2, "Personal Computer", "Specification of PC", 3 },
                    { 10, 2, "MO000005", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2027), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2028), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 8, 2, "MO000003", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2023), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2024), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 7, 2, "MO000002", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2021), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2022), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 6, 2, "MO000001", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2019), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2020), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 19, 1, "LA000009", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2102), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2103), 2, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 },
                    { 18, 1, "LA000008", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2099), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2100), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 3 },
                    { 17, 1, "LA000007", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2042), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2043), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 },
                    { 16, 1, "LA000006", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2040), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2041), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 },
                    { 5, 1, "LA000005", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2017), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2017), 2, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 4, 1, "LA000004", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2015), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2015), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 3, 1, "LA000003", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2011), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2012), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 2, 1, "LA000002", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2000), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2009), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 9, 2, "MO000004", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2025), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2026), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 27, 3, "PC000008", new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2118), false, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2119), 2, "Personal Computer", "Specification of PC", 2 }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssetID", "AssignByID", "AssignDate", "AssignToID", "Location", "Note", "ReturnDate", "State" },
                values: new object[,]
                {
                    { 1, 16, 4, new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(9954), 14, 1, "Assign asset to this staff.", null, 1 },
                    { 2, 17, 4, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(829), 15, 1, "Assign asset to this staff.", null, 1 },
                    { 3, 18, 4, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(834), 16, 1, "Assign asset to this staff.", null, 2 },
                    { 4, 19, 6, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(836), 8, 2, "Assign asset to this staff.", null, 1 },
                    { 5, 20, 4, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(838), 17, 1, "Assign asset to this staff.", null, 2 },
                    { 6, 21, 6, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(839), 9, 2, "Assign asset to this staff.", null, 1 },
                    { 7, 22, 6, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(841), 10, 2, "Assign asset to this staff.", null, 1 },
                    { 8, 23, 4, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(846), 14, 1, "Assign asset to this staff.", null, 2 },
                    { 9, 24, 4, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(847), 14, 1, "Assign asset to this staff.", null, 2 },
                    { 10, 25, 6, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(849), 11, 2, "Assign asset to this staff.", null, 2 },
                    { 11, 26, 6, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(850), 12, 2, "Assign asset to this staff.", null, 2 },
                    { 12, 27, 4, new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(852), 12, 2, "Assign asset to this staff.", null, 1 }
                });
        }
    }
}
