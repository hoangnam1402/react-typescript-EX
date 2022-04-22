using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class add_isdisable_column_to_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisable",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisable",
                table: "Users");
        }
    }
}
