using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class add_assetcategory_and_asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "AssetCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "CategoryID", "Code", "InstallDate", "LastUpdate", "Location", "Name", "Specification", "State" },
                values: new object[,]
                {
                    { 1, 1, "LA000001", new DateTime(2023, 4, 2, 9, 8, 21, 781, DateTimeKind.Local).AddTicks(3913), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(3042), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 2, 1, "LA000002", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4366), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4375), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 3, 1, "LA000003", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4378), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4379), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 4, 1, "LA000004", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4380), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4381), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 },
                    { 5, 1, "LA000005", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4382), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4383), 2, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 1 },
                    { 6, 2, "MO000001", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4385), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4386), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 7, 2, "MO000002", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4387), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4388), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 2 },
                    { 8, 2, "MO000003", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4389), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4390), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 9, 2, "MO000004", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4391), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4392), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 10, 2, "MO000005", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4394), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4394), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 2 },
                    { 11, 2, "MO000006", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4396), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4397), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 1 },
                    { 12, 3, "PC000001", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4398), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4399), 1, "Personal Computer", "Specification of PC", 1 },
                    { 13, 3, "PC000002", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4400), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4401), 1, "Personal Computer", "Specification of PC", 2 },
                    { 14, 3, "PC000003", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4403), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4403), 2, "Personal Computer", "Specification of PC", 1 },
                    { 15, 3, "PC000004", new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4405), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4406), 2, "Personal Computer", "Specification of PC", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryID",
                table: "Assets",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AssetCategories");
        }
    }
}
