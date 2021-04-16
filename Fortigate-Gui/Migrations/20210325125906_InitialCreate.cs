using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Fortigate");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Fortigate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Fortigate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "Zone",
                schema: "Fortigate",
                columns: table => new
                {
                    ZoneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.ZoneID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Fortigate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Fortigate",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Fortigate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Fortigate",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Fortigate",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Fortigate",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Fortigate",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Fortigate",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Fortigate",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Fortigate",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Fortigate",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Alias = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    SecondaryIp = table.Column<bool>(nullable: false),
                    Subnet = table.Column<string>(nullable: true),
                    EnumAccesID = table.Column<int>(nullable: false),
                    EnumModeID = table.Column<int>(nullable: false)
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
                        name: "FK_Interface_EnumMode_EnumModeID",
                        column: x => x.EnumModeID,
                        principalSchema: "Fortigate",
                        principalTable: "EnumMode",
                        principalColumn: "EnumModeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirewallAddress",
                schema: "Fortigate",
                columns: table => new
                {
                    FirewallAddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AssociatedZoneZoneID = table.Column<int>(nullable: true),
                    Subnet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirewallAddress", x => x.FirewallAddressID);
                    table.ForeignKey(
                        name: "FK_FirewallAddress_Zone_AssociatedZoneZoneID",
                        column: x => x.AssociatedZoneZoneID,
                        principalSchema: "Fortigate",
                        principalTable: "Zone",
                        principalColumn: "ZoneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZoneInterface",
                schema: "Fortigate",
                columns: table => new
                {
                    ZoneInterfaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterfaceID = table.Column<int>(nullable: false),
                    ZoneID = table.Column<int>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZoneInterface_Zone_ZoneID",
                        column: x => x.ZoneID,
                        principalSchema: "Fortigate",
                        principalTable: "Zone",
                        principalColumn: "ZoneID",
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
                    Admin = table.Column<bool>(nullable: false),
                    ConfigfileID = table.Column<int>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Fortigate",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_ConfigFile_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "Fortigate",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfigFile_Filter_FilterID",
                        column: x => x.FilterID,
                        principalSchema: "Fortigate",
                        principalTable: "Filter",
                        principalColumn: "FilterID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Fortigate",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Fortigate",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Fortigate",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Fortigate",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Fortigate",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Fortigate",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Fortigate",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Customer_UserID",
                schema: "Fortigate",
                table: "Customer",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ClientID",
                schema: "Fortigate",
                table: "Employee",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_FirewallAddress_AssociatedZoneZoneID",
                schema: "Fortigate",
                table: "FirewallAddress",
                column: "AssociatedZoneZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumAccesID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumAccesID");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumModeID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumModeID");

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
                name: "FK_Customer_ConfigFile_ConfigfileID",
                schema: "Fortigate",
                table: "Customer",
                column: "ConfigfileID",
                principalSchema: "Fortigate",
                principalTable: "ConfigFile",
                principalColumn: "ConfigfileID",
                onDelete: ReferentialAction.Restrict);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_UserID",
                schema: "Fortigate",
                table: "Customer");

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

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "FirewallAddress",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "ZoneInterface",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "ZonePolicy",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Interface",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Zone",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "EnumAcces",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "EnumMode",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
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
        }
    }
}
