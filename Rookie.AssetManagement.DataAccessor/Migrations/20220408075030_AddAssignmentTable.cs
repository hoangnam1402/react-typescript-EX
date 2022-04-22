using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class AddAssignmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    AssignByID = table.Column<int>(type: "int", nullable: true),
                    AssignToID = table.Column<int>(type: "int", nullable: true),
                    AssignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_AssignByID",
                        column: x => x.AssignByID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_AssignToID",
                        column: x => x.AssignToID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 990, DateTimeKind.Local).AddTicks(601), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(1655) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3226), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3241) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3245), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3247) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3248), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3250), 1 });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3252), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3254) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3256), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3258), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3259), 1 });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3262), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3264) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3265), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3267), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3268), 1 });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3270), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3272), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3274), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3275), 1 });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3276), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3279), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3280), 1 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "CategoryID", "Code", "InstallDate", "LastUpdate", "Location", "Name", "Specification", "State" },
                values: new object[,]
                {
                    { 26, 3, "PC000007", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3314), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3315), 2, "Personal Computer", "Specification of PC", 3 },
                    { 25, 3, "PC000006", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3312), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3313), 1, "Personal Computer", "Specification of PC", 3 },
                    { 24, 3, "PC000005", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3310), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3311), 1, "Personal Computer", "Specification of PC", 3 },
                    { 23, 2, "MO0000010", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3307), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3308), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 3 },
                    { 22, 2, "MO000009", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3305), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3306), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 2 },
                    { 21, 2, "MO000008", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3303), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3304), 2, "Monitor Dell UltraSharp", "Specification of Monitor", 2 },
                    { 20, 2, "MO000007", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3290), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3291), 1, "Monitor Dell UltraSharp", "Specification of Monitor", 3 },
                    { 19, 1, "LA000009", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3288), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3288), 2, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 },
                    { 18, 1, "LA000008", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3285), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3286), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 3 },
                    { 17, 1, "LA000007", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3283), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3284), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 },
                    { 27, 3, "PC000008", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3316), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3317), 2, "Personal Computer", "Specification of PC", 2 },
                    { 16, 1, "LA000006", new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3281), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3282), 1, "Laptop HP Pro Book 450 G1", "Specification of Laptop", 2 }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssetID", "AssignByID", "AssignDate", "AssignToID", "Note", "ReturnDate", "State" },
                values: new object[,]
                {
                    { 1, 16, 4, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(3649), 14, "Assign asset to this staff.", null, 1 },
                    { 2, 17, 4, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4715), 15, "Assign asset to this staff.", null, 1 },
                    { 3, 18, 4, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4721), 16, "Assign asset to this staff.", null, 2 },
                    { 4, 19, 6, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4723), 8, "Assign asset to this staff.", null, 1 },
                    { 5, 20, 4, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4726), 17, "Assign asset to this staff.", null, 2 },
                    { 6, 21, 6, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4727), 9, "Assign asset to this staff.", null, 1 },
                    { 7, 22, 6, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4728), 10, "Assign asset to this staff.", null, 1 },
                    { 8, 23, 4, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4730), 14, "Assign asset to this staff.", null, 2 },
                    { 9, 24, 4, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4731), 14, "Assign asset to this staff.", null, 2 },
                    { 10, 25, 6, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4732), 11, "Assign asset to this staff.", null, 2 },
                    { 11, 26, 6, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4734), 12, "Assign asset to this staff.", null, 2 },
                    { 12, 27, 4, new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4735), 12, "Assign asset to this staff.", null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssetID",
                table: "Assignments",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignByID",
                table: "Assignments",
                column: "AssignByID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignToID",
                table: "Assignments",
                column: "AssignToID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

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

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 781, DateTimeKind.Local).AddTicks(3913), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(3042) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4366), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4375) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4378), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4379) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4380), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4381), 2 });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4382), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4383) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4385), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4386) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4387), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4388), 2 });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4389), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4391), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4392) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4394), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4394), 2 });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4396), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4397) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4398), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4399) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4400), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4401), 2 });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4403), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4403) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "InstallDate", "LastUpdate", "State" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4405), new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4406), 2 });
        }
    }
}
