using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Data.Migrations
{
    public partial class EnumAliasAlias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interface_EnumAlias_EnumAliasID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropTable(
                name: "EnumAlias",
                schema: "Fortigate");

            migrationBuilder.DropIndex(
                name: "IX_Interface_EnumAliasID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropColumn(
                name: "EnumAliasID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                schema: "Fortigate",
                table: "Interface",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.AddColumn<int>(
                name: "EnumAliasID",
                schema: "Fortigate",
                table: "Interface",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EnumAlias",
                schema: "Fortigate",
                columns: table => new
                {
                    EnumAliasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumAlias", x => x.EnumAliasID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumAliasID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumAliasID");

            migrationBuilder.AddForeignKey(
                name: "FK_Interface_EnumAlias_EnumAliasID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumAliasID",
                principalSchema: "Fortigate",
                principalTable: "EnumAlias",
                principalColumn: "EnumAliasID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
