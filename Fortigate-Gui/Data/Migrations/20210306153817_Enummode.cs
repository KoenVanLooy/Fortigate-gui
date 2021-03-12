using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Data.Migrations
{
    public partial class Enummode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interface_EnumMode_EnumModeID1",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropIndex(
                name: "IX_Interface_EnumModeID1",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropColumn(
                name: "EnumModeID1",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.AlterColumn<int>(
                name: "EnumModeID",
                schema: "Fortigate",
                table: "Interface",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumModeID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumModeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Interface_EnumMode_EnumModeID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumModeID",
                principalSchema: "Fortigate",
                principalTable: "EnumMode",
                principalColumn: "EnumModeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interface_EnumMode_EnumModeID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropIndex(
                name: "IX_Interface_EnumModeID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.AlterColumn<string>(
                name: "EnumModeID",
                schema: "Fortigate",
                table: "Interface",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EnumModeID1",
                schema: "Fortigate",
                table: "Interface",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumModeID1",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumModeID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Interface_EnumMode_EnumModeID1",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumModeID1",
                principalSchema: "Fortigate",
                principalTable: "EnumMode",
                principalColumn: "EnumModeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
