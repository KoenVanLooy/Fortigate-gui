using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Migrations
{
    public partial class physicalinterface1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnumPhysicalID",
                schema: "Fortigate",
                table: "Interface",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumPhysicalID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumPhysicalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Interface_EnumPhysical_EnumPhysicalID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumPhysicalID",
                principalSchema: "Fortigate",
                principalTable: "EnumPhysical",
                principalColumn: "EnumPhysicalID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interface_EnumPhysical_EnumPhysicalID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropIndex(
                name: "IX_Interface_EnumPhysicalID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropColumn(
                name: "EnumPhysicalID",
                schema: "Fortigate",
                table: "Interface");
        }
    }
}
