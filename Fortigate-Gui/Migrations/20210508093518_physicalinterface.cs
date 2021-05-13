using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Migrations
{
    public partial class physicalinterface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnumPhysical",
                schema: "Fortigate",
                columns: table => new
                {
                    EnumPhysicalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumPhysical", x => x.EnumPhysicalID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnumPhysical",
                schema: "Fortigate");
        }
    }
}
