using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Data.Migrations
{
    public partial class VpnRewrite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigFile_VPNtunnel_VPNtunnelID",
                schema: "Fortigate",
                table: "ConfigFile");

            migrationBuilder.DropForeignKey(
                name: "FK_Setting_VPNtunnel_VPNtunnelID",
                schema: "Fortigate",
                table: "Setting");

            migrationBuilder.DropTable(
                name: "VPNtunnel",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Setting",
                schema: "Fortigate");

            migrationBuilder.DropIndex(
                name: "IX_ConfigFile_VPNtunnelID",
                schema: "Fortigate",
                table: "ConfigFile");

            migrationBuilder.DropColumn(
                name: "VPNtunnelID",
                schema: "Fortigate",
                table: "ConfigFile");

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Fortigate",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ConfigFileID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupID);
                    table.ForeignKey(
                        name: "FK_Group_ConfigFile_ConfigFileID",
                        column: x => x.ConfigFileID,
                        principalSchema: "Fortigate",
                        principalTable: "ConfigFile",
                        principalColumn: "ConfigfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Fortigate",
                columns: table => new
                {
                    FortiUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 35, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.FortiUserID);
                });

            migrationBuilder.CreateTable(
                name: "VpnPortal",
                schema: "Fortigate",
                columns: table => new
                {
                    VpnPortalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalName = table.Column<string>(maxLength: 35, nullable: false),
                    TunnelMode = table.Column<bool>(nullable: false),
                    SplitTunneling = table.Column<bool>(nullable: false),
                    WebMode = table.Column<bool>(nullable: false),
                    AutoConnect = table.Column<bool>(nullable: false),
                    KeepAlive = table.Column<bool>(nullable: false),
                    SavePassword = table.Column<bool>(nullable: false),
                    IpPool = table.Column<string>(maxLength: 79, nullable: false),
                    SplitTunnelingRoute = table.Column<string>(maxLength: 79, nullable: true),
                    ConfigFileID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VpnPortal", x => x.VpnPortalID);
                    table.ForeignKey(
                        name: "FK_VpnPortal_ConfigFile_ConfigFileID",
                        column: x => x.ConfigFileID,
                        principalSchema: "Fortigate",
                        principalTable: "ConfigFile",
                        principalColumn: "ConfigfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                schema: "Fortigate",
                columns: table => new
                {
                    UserGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FortiUserID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.UserGroupID);
                    table.ForeignKey(
                        name: "FK_UserGroup_User_FortiUserID",
                        column: x => x.FortiUserID,
                        principalSchema: "Fortigate",
                        principalTable: "User",
                        principalColumn: "FortiUserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroup_Group_GroupID",
                        column: x => x.GroupID,
                        principalSchema: "Fortigate",
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VpnSetting",
                schema: "Fortigate",
                columns: table => new
                {
                    VpnSettingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerCert = table.Column<string>(maxLength: 35, nullable: false),
                    TunnelIpPool = table.Column<string>(maxLength: 79, nullable: false),
                    TunnelIpv6Pool = table.Column<string>(maxLength: 79, nullable: false),
                    SourceInterface = table.Column<string>(maxLength: 35, nullable: false),
                    SourceAddress = table.Column<string>(maxLength: 79, nullable: false),
                    SourceAddressV6 = table.Column<string>(maxLength: 79, nullable: false),
                    DefaultPort = table.Column<string>(maxLength: 35, nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    VpnPortalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VpnSetting", x => x.VpnSettingID);
                    table.ForeignKey(
                        name: "FK_VpnSetting_Group_GroupID",
                        column: x => x.GroupID,
                        principalSchema: "Fortigate",
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VpnSetting_VpnPortal_VpnPortalID",
                        column: x => x.VpnPortalID,
                        principalSchema: "Fortigate",
                        principalTable: "VpnPortal",
                        principalColumn: "VpnPortalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_ConfigFileID",
                schema: "Fortigate",
                table: "Group",
                column: "ConfigFileID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_FortiUserID",
                schema: "Fortigate",
                table: "UserGroup",
                column: "FortiUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupID",
                schema: "Fortigate",
                table: "UserGroup",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_VpnPortal_ConfigFileID",
                schema: "Fortigate",
                table: "VpnPortal",
                column: "ConfigFileID");

            migrationBuilder.CreateIndex(
                name: "IX_VpnSetting_GroupID",
                schema: "Fortigate",
                table: "VpnSetting",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_VpnSetting_VpnPortalID",
                schema: "Fortigate",
                table: "VpnSetting",
                column: "VpnPortalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGroup",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "VpnSetting",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "VpnPortal",
                schema: "Fortigate");

            migrationBuilder.AddColumn<int>(
                name: "VPNtunnelID",
                schema: "Fortigate",
                table: "ConfigFile",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VPNtunnel",
                schema: "Fortigate",
                columns: table => new
                {
                    VPNtunnelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigfileID = table.Column<int>(type: "int", nullable: true),
                    IpPool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettingID = table.Column<int>(type: "int", nullable: true),
                    SplitTunneling = table.Column<bool>(type: "bit", nullable: false),
                    TunnelMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VPNtunnel", x => x.VPNtunnelID);
                    table.ForeignKey(
                        name: "FK_VPNtunnel_ConfigFile_ConfigfileID",
                        column: x => x.ConfigfileID,
                        principalSchema: "Fortigate",
                        principalTable: "ConfigFile",
                        principalColumn: "ConfigfileID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                schema: "Fortigate",
                columns: table => new
                {
                    SettingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultPort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerCert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceAddressV6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceInterface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringSourceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TunnelIpPool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TunnelIpv6Pool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VPNtunnelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.SettingID);
                    table.ForeignKey(
                        name: "FK_Setting_VPNtunnel_VPNtunnelID",
                        column: x => x.VPNtunnelID,
                        principalSchema: "Fortigate",
                        principalTable: "VPNtunnel",
                        principalColumn: "VPNtunnelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigFile_VPNtunnelID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "VPNtunnelID");

            migrationBuilder.CreateIndex(
                name: "IX_Setting_VPNtunnelID",
                schema: "Fortigate",
                table: "Setting",
                column: "VPNtunnelID");

            migrationBuilder.CreateIndex(
                name: "IX_VPNtunnel_ConfigfileID",
                schema: "Fortigate",
                table: "VPNtunnel",
                column: "ConfigfileID");

            migrationBuilder.CreateIndex(
                name: "IX_VPNtunnel_SettingID",
                schema: "Fortigate",
                table: "VPNtunnel",
                column: "SettingID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigFile_VPNtunnel_VPNtunnelID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "VPNtunnelID",
                principalSchema: "Fortigate",
                principalTable: "VPNtunnel",
                principalColumn: "VPNtunnelID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VPNtunnel_Setting_SettingID",
                schema: "Fortigate",
                table: "VPNtunnel",
                column: "SettingID",
                principalSchema: "Fortigate",
                principalTable: "Setting",
                principalColumn: "SettingID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
