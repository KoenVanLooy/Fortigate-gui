using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Data.Migrations
{
    public partial class ModelsCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Fortigate");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "Fortigate");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "Fortigate");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "Fortigate");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "Fortigate");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "Fortigate");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "Fortigate");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "Fortigate");

            migrationBuilder.CreateTable(
                name: "EnumAcces",
                schema: "Fortigate",
                columns: table => new
                {
                    EnumAccesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumAcces", x => x.EnumAccesID);
                });

            migrationBuilder.CreateTable(
                name: "EnumAlias",
                schema: "Fortigate",
                columns: table => new
                {
                    EnumAliasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumAlias", x => x.EnumAliasID);
                });

            migrationBuilder.CreateTable(
                name: "EnumMode",
                schema: "Fortigate",
                columns: table => new
                {
                    EnumModeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumMode", x => x.EnumModeID);
                });

            migrationBuilder.CreateTable(
                name: "Filter",
                schema: "Fortigate",
                columns: table => new
                {
                    FilterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigFilter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.FilterID);
                });

            migrationBuilder.CreateTable(
                name: "ConfigFile",
                schema: "Fortigate",
                columns: table => new
                {
                    ConfigfileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ClientID = table.Column<int>(nullable: false),
                    FilterID = table.Column<int>(nullable: false),
                    Ip4PolicyID = table.Column<int>(nullable: true),
                    VPNtunnelID = table.Column<int>(nullable: true),
                    CustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigFile", x => x.ConfigfileID);
                    table.ForeignKey(
                        name: "FK_ConfigFile_Filter_FilterID",
                        column: x => x.FilterID,
                        principalSchema: "Fortigate",
                        principalTable: "Filter",
                        principalColumn: "FilterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Fortigate",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ConfigfileID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_ConfigFile_ConfigfileID",
                        column: x => x.ConfigfileID,
                        principalSchema: "Fortigate",
                        principalTable: "ConfigFile",
                        principalColumn: "ConfigfileID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ip4Policy",
                schema: "Fortigate",
                columns: table => new
                {
                    Ip4PolicyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceInterface = table.Column<string>(nullable: true),
                    DestinationInterface = table.Column<string>(nullable: true),
                    SourceAddress = table.Column<string>(nullable: true),
                    DestinationAddress = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ConfigfileID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ip4Policy", x => x.Ip4PolicyID);
                    table.ForeignKey(
                        name: "FK_Ip4Policy_ConfigFile_ConfigfileID",
                        column: x => x.ConfigfileID,
                        principalSchema: "Fortigate",
                        principalTable: "ConfigFile",
                        principalColumn: "ConfigfileID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "Fortigate",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ClientID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "Fortigate",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryName = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Client_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "Fortigate",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VPNtunnel",
                schema: "Fortigate",
                columns: table => new
                {
                    VPNtunnelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TunnelMode = table.Column<bool>(nullable: false),
                    SplitTunneling = table.Column<bool>(nullable: false),
                    IpPool = table.Column<string>(nullable: true),
                    SettingID = table.Column<int>(nullable: true),
                    ConfigfileID = table.Column<int>(nullable: true)
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
                    SettingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerCert = table.Column<string>(nullable: true),
                    TunnelIpPool = table.Column<string>(nullable: true),
                    TunnelIpv6Pool = table.Column<string>(nullable: true),
                    SourceInterface = table.Column<string>(nullable: true),
                    StringSourceAddress = table.Column<string>(nullable: true),
                    SourceAddress = table.Column<string>(nullable: true),
                    SourceAddressV6 = table.Column<string>(nullable: true),
                    DefaultPort = table.Column<string>(nullable: true),
                    VPNtunnelID = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Interface",
                schema: "Fortigate",
                columns: table => new
                {
                    InterfaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Vdom = table.Column<string>(nullable: true),
                    EnumAliasID = table.Column<int>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    SecondaryIp = table.Column<bool>(nullable: false),
                    Subnet = table.Column<string>(nullable: true),
                    EnumAccesID = table.Column<int>(nullable: false),
                    EnumModeID = table.Column<string>(nullable: true),
                    EnumModeID1 = table.Column<int>(nullable: true),
                    ZoneInterfaceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface", x => x.InterfaceID);
                    table.ForeignKey(
                        name: "FK_Interface_EnumAcces_EnumAccesID",
                        column: x => x.EnumAccesID,
                        principalSchema: "Fortigate",
                        principalTable: "EnumAcces",
                        principalColumn: "EnumAccesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interface_EnumAlias_EnumAliasID",
                        column: x => x.EnumAliasID,
                        principalSchema: "Fortigate",
                        principalTable: "EnumAlias",
                        principalColumn: "EnumAliasID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interface_EnumMode_EnumModeID1",
                        column: x => x.EnumModeID1,
                        principalSchema: "Fortigate",
                        principalTable: "EnumMode",
                        principalColumn: "EnumModeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZoneInterface",
                schema: "Fortigate",
                columns: table => new
                {
                    ZoneInterfaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneID = table.Column<int>(nullable: true),
                    InterfaceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneInterface", x => x.ZoneInterfaceID);
                    table.ForeignKey(
                        name: "FK_ZoneInterface_Interface_InterfaceID",
                        column: x => x.InterfaceID,
                        principalSchema: "Fortigate",
                        principalTable: "Interface",
                        principalColumn: "InterfaceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                schema: "Fortigate",
                columns: table => new
                {
                    ZoneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ZoneInterfaceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.ZoneID);
                    table.ForeignKey(
                        name: "FK_Zone_ZoneInterface_ZoneInterfaceID",
                        column: x => x.ZoneInterfaceID,
                        principalSchema: "Fortigate",
                        principalTable: "ZoneInterface",
                        principalColumn: "ZoneInterfaceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZonePolicy",
                schema: "Fortigate",
                columns: table => new
                {
                    ZonePolicyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ip4PolicyID = table.Column<int>(nullable: false),
                    ZoneID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonePolicy", x => x.ZonePolicyID);
                    table.ForeignKey(
                        name: "FK_ZonePolicy_Ip4Policy_Ip4PolicyID",
                        column: x => x.Ip4PolicyID,
                        principalSchema: "Fortigate",
                        principalTable: "Ip4Policy",
                        principalColumn: "Ip4PolicyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZonePolicy_Zone_ZoneID",
                        column: x => x.ZoneID,
                        principalSchema: "Fortigate",
                        principalTable: "Zone",
                        principalColumn: "ZoneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_EmployeeID",
                schema: "Fortigate",
                table: "Client",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigFile_ClientID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigFile_CustomerID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigFile_FilterID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "FilterID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigFile_Ip4PolicyID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "Ip4PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigFile_VPNtunnelID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "VPNtunnelID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ConfigfileID",
                schema: "Fortigate",
                table: "Customer",
                column: "ConfigfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ClientID",
                schema: "Fortigate",
                table: "Employee",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumAccesID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumAccesID");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumAliasID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumAliasID");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumModeID1",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumModeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_ZoneInterfaceID",
                schema: "Fortigate",
                table: "Interface",
                column: "ZoneInterfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Ip4Policy_ConfigfileID",
                schema: "Fortigate",
                table: "Ip4Policy",
                column: "ConfigfileID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Zone_ZoneInterfaceID",
                schema: "Fortigate",
                table: "Zone",
                column: "ZoneInterfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneInterface_InterfaceID",
                schema: "Fortigate",
                table: "ZoneInterface",
                column: "InterfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneInterface_ZoneID",
                schema: "Fortigate",
                table: "ZoneInterface",
                column: "ZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_ZonePolicy_Ip4PolicyID",
                schema: "Fortigate",
                table: "ZonePolicy",
                column: "Ip4PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_ZonePolicy_ZoneID",
                schema: "Fortigate",
                table: "ZonePolicy",
                column: "ZoneID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigFile_Client_ClientID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "ClientID",
                principalSchema: "Fortigate",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigFile_Customer_CustomerID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "CustomerID",
                principalSchema: "Fortigate",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigFile_Ip4Policy_Ip4PolicyID",
                schema: "Fortigate",
                table: "ConfigFile",
                column: "Ip4PolicyID",
                principalSchema: "Fortigate",
                principalTable: "Ip4Policy",
                principalColumn: "Ip4PolicyID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Employee_Client_ClientID",
                schema: "Fortigate",
                table: "Employee",
                column: "ClientID",
                principalSchema: "Fortigate",
                principalTable: "Client",
                principalColumn: "ClientID",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Interface_ZoneInterface_ZoneInterfaceID",
                schema: "Fortigate",
                table: "Interface",
                column: "ZoneInterfaceID",
                principalSchema: "Fortigate",
                principalTable: "ZoneInterface",
                principalColumn: "ZoneInterfaceID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneInterface_Zone_ZoneID",
                schema: "Fortigate",
                table: "ZoneInterface",
                column: "ZoneID",
                principalSchema: "Fortigate",
                principalTable: "Zone",
                principalColumn: "ZoneID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Employee_EmployeeID",
                schema: "Fortigate",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfigFile_Client_ClientID",
                schema: "Fortigate",
                table: "ConfigFile");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfigFile_Customer_CustomerID",
                schema: "Fortigate",
                table: "ConfigFile");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfigFile_Filter_FilterID",
                schema: "Fortigate",
                table: "ConfigFile");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfigFile_Ip4Policy_Ip4PolicyID",
                schema: "Fortigate",
                table: "ConfigFile");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfigFile_VPNtunnel_VPNtunnelID",
                schema: "Fortigate",
                table: "ConfigFile");

            migrationBuilder.DropForeignKey(
                name: "FK_Setting_VPNtunnel_VPNtunnelID",
                schema: "Fortigate",
                table: "Setting");

            migrationBuilder.DropForeignKey(
                name: "FK_Interface_EnumAcces_EnumAccesID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropForeignKey(
                name: "FK_Interface_EnumAlias_EnumAliasID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropForeignKey(
                name: "FK_Interface_EnumMode_EnumModeID1",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropForeignKey(
                name: "FK_Interface_ZoneInterface_ZoneInterfaceID",
                schema: "Fortigate",
                table: "Interface");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_ZoneInterface_ZoneInterfaceID",
                schema: "Fortigate",
                table: "Zone");

            migrationBuilder.DropTable(
                name: "ZonePolicy",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Filter",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Ip4Policy",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "VPNtunnel",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "ConfigFile",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Setting",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "EnumAcces",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "EnumAlias",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "EnumMode",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "ZoneInterface",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Interface",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Zone",
                schema: "Fortigate");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Fortigate",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Fortigate",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Fortigate",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Fortigate",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Fortigate",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Fortigate",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Fortigate",
                newName: "AspNetRoleClaims");
        }
    }
}
