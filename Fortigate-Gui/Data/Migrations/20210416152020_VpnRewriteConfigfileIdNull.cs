using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Data.Migrations
{
    public partial class VpnRewriteConfigfileIdNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VpnPortal_ConfigFile_ConfigFileID",
                schema: "Fortigate",
                table: "VpnPortal");

            migrationBuilder.AlterColumn<int>(
                name: "ConfigFileID",
                schema: "Fortigate",
                table: "VpnPortal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VpnPortal_ConfigFile_ConfigFileID",
                schema: "Fortigate",
                table: "VpnPortal",
                column: "ConfigFileID",
                principalSchema: "Fortigate",
                principalTable: "ConfigFile",
                principalColumn: "ConfigfileID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VpnPortal_ConfigFile_ConfigFileID",
                schema: "Fortigate",
                table: "VpnPortal");

            migrationBuilder.AlterColumn<int>(
                name: "ConfigFileID",
                schema: "Fortigate",
                table: "VpnPortal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VpnPortal_ConfigFile_ConfigFileID",
                schema: "Fortigate",
                table: "VpnPortal",
                column: "ConfigFileID",
                principalSchema: "Fortigate",
                principalTable: "ConfigFile",
                principalColumn: "ConfigfileID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
