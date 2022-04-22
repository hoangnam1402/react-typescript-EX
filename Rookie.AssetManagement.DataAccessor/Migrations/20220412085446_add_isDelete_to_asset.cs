using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class add_isDelete_to_asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Assets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 726, DateTimeKind.Local).AddTicks(3942), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2000), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2009) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2011), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2012) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2015), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2015) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2017), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2017) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2019), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2020) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2021), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2022) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2023), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2024) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2025), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2027), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2028) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2030), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2031) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2032), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2034), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2035) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2036), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2037) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2038), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2039) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2040), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2041) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2042), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2043) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2099), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2100) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2102), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2103) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2104), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2106), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2108), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2109) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2110), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2111) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2112), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2113) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2114), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2115) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2116), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "InstallDate", "LastUpdate" },
                values: new object[] { new DateTime(2023, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2118), new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(2119) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 727, DateTimeKind.Local).AddTicks(9954), 1 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(829), 1 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(834), 1 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(836), 2 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(838), 1 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(839), 2 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(841), 2 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(846), 1 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(847), 1 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(849), 2 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(850), 2 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 12, 15, 54, 45, 728, DateTimeKind.Local).AddTicks(852), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Assets");

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
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(1908), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2511), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2516), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2517), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2519), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2520), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2521), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2523), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2524), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2525), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2527), 0 });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AssignDate", "Location" },
                values: new object[] { new DateTime(2022, 4, 8, 15, 16, 19, 486, DateTimeKind.Local).AddTicks(2528), 0 });
        }
    }
}
