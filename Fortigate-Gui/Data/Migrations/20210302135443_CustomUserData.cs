using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Data.Migrations
{
    public partial class CustomUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Fortigate",
                table: "Customer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserID",
                schema: "Fortigate",
                table: "Customer",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_UserID",
                schema: "Fortigate",
                table: "Customer",
                column: "UserID",
                principalSchema: "Fortigate",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_UserID",
                schema: "Fortigate",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_UserID",
                schema: "Fortigate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Fortigate",
                table: "Customer");
        }
    }
}
