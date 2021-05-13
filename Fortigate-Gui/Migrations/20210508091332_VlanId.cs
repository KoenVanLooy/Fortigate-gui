using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Migrations
{
    public partial class VlanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryIp",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.AddColumn<int>(
                name: "VlanId",
                schema: "Fortigate",
                table: "Interface",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VlanId",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.AddColumn<bool>(
                name: "SecondaryIp",
                schema: "Fortigate",
                table: "Interface",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
