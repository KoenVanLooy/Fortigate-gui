using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Migrations
{
    public partial class GroupNotConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_ConfigFile_ConfigFileID",
                schema: "Fortigate",
                table: "Group");

            migrationBuilder.AlterColumn<int>(
                name: "ConfigFileID",
                schema: "Fortigate",
                table: "Group",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_ConfigFile_ConfigFileID",
                schema: "Fortigate",
                table: "Group",
                column: "ConfigFileID",
                principalSchema: "Fortigate",
                principalTable: "ConfigFile",
                principalColumn: "ConfigfileID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_ConfigFile_ConfigFileID",
                schema: "Fortigate",
                table: "Group");

            migrationBuilder.AlterColumn<int>(
                name: "ConfigFileID",
                schema: "Fortigate",
                table: "Group",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_ConfigFile_ConfigFileID",
                schema: "Fortigate",
                table: "Group",
                column: "ConfigFileID",
                principalSchema: "Fortigate",
                principalTable: "ConfigFile",
                principalColumn: "ConfigfileID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
