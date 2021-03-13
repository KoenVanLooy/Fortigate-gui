using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Data.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Fortigate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Username",
                schema: "Fortigate",
                table: "Customer");

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                schema: "Fortigate",
                table: "Customer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                schema: "Fortigate",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "Fortigate",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "Fortigate",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
