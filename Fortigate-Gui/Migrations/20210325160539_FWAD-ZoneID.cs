using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Migrations
{
    public partial class FWADZoneID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirewallAddress_Zone_AssociatedZoneZoneID",
                schema: "Fortigate",
                table: "FirewallAddress");

            migrationBuilder.DropIndex(
                name: "IX_FirewallAddress_AssociatedZoneZoneID",
                schema: "Fortigate",
                table: "FirewallAddress");

            migrationBuilder.DropColumn(
                name: "AssociatedZoneZoneID",
                schema: "Fortigate",
                table: "FirewallAddress");

            migrationBuilder.AddColumn<string>(
                name: "AssociatedZone",
                schema: "Fortigate",
                table: "FirewallAddress",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssociatedZone",
                schema: "Fortigate",
                table: "FirewallAddress");

            migrationBuilder.AddColumn<int>(
                name: "AssociatedZoneZoneID",
                schema: "Fortigate",
                table: "FirewallAddress",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FirewallAddress_AssociatedZoneZoneID",
                schema: "Fortigate",
                table: "FirewallAddress",
                column: "AssociatedZoneZoneID");

            migrationBuilder.AddForeignKey(
                name: "FK_FirewallAddress_Zone_AssociatedZoneZoneID",
                schema: "Fortigate",
                table: "FirewallAddress",
                column: "AssociatedZoneZoneID",
                principalSchema: "Fortigate",
                principalTable: "Zone",
                principalColumn: "ZoneID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
