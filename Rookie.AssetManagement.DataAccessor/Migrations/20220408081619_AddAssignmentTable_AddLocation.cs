using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class AddAssignmentTable_AddLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 484, DateTimeKind.Local).AddTicks(6404), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(4442) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5385), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5394) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5396), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5397) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5398), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5399) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5400), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5401) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5402), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5403) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5405), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5406) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5407), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5408) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5409), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5411), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5412) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5413), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5414) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5415), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5418), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5418) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5420), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5420) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5422), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5422) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5424), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5424) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5426), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5427) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5428), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5429) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5430), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5431) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5432), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5433) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5434), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5438), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5438) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5439), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5488), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5489) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5491), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5492) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5493), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5494) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5495), new DateTime(2022, 4, 8, 15, 16, 19, 485, DateTimeKind.Local).AddTicks(5496) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 11,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 12,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2528));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Assignments");

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
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3248), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3250) });

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
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3258), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3259) });

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
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3267), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3268) });

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
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3274), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3275) });

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
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3279), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3281), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3282) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3283), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3284) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3285), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3286) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3288), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3290), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3291) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3303), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3304) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3305), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3306) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3307), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3308) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3310), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3311) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3312), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3314), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3315) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3316), new DateTime(2022, 4, 8, 14, 50, 29, 991, DateTimeKind.Local).AddTicks(3317) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 11,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 12,
                column: "AssignDate",
                value: new DateTime(2022, 4, 8, 14, 50, 29, 992, DateTimeKind.Local).AddTicks(4735));
        }
    }
}
