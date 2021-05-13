using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortigate_Gui.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Fortigate");

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "Fortigate",
                columns: table => new
                {
                    ActionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.ActionID);
                });

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

            migrationBuilder.CreateTable(
                name: "EnumType",
                schema: "Fortigate",
                columns: table => new
                {
                    EnumTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumType", x => x.EnumTypeID);
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
                name: "FirewallAddress",
                schema: "Fortigate",
                columns: table => new
                {
                    FirewallAddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AssociatedZone = table.Column<string>(nullable: true),
                    Subnet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirewallAddress", x => x.FirewallAddressID);
                });

            migrationBuilder.CreateTable(
                name: "Nat",
                schema: "Fortigate",
                columns: table => new
                {
                    NatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nat", x => x.NatID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                schema: "Fortigate",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
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
                    Alias = table.Column<string>(maxLength: 20, nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    VlanId = table.Column<int>(nullable: false),
                    Subnet = table.Column<string>(maxLength: 20, nullable: false),
                    EnumModeID = table.Column<int>(nullable: false),
                    EnumTypeID = table.Column<int>(nullable: false),
                    EnumPhysicalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface", x => x.InterfaceID);
                    table.ForeignKey(
                        name: "FK_Interface_EnumMode_EnumModeID",
                        column: x => x.EnumModeID,
                        principalSchema: "Fortigate",
                        principalTable: "EnumMode",
                        principalColumn: "EnumModeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interface_EnumPhysical_EnumPhysicalID",
                        column: x => x.EnumPhysicalID,
                        principalSchema: "Fortigate",
                        principalTable: "EnumPhysical",
                        principalColumn: "EnumPhysicalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interface_EnumType_EnumTypeID",
                        column: x => x.EnumTypeID,
                        principalSchema: "Fortigate",
                        principalTable: "EnumType",
                        principalColumn: "EnumTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessInterface",
                schema: "Fortigate",
                columns: table => new
                {
                    AccessInterfaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterfaceID = table.Column<int>(nullable: false),
                    EnumAccesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessInterface", x => x.AccessInterfaceID);
                    table.ForeignKey(
                        name: "FK_AccessInterface_EnumAcces_EnumAccesID",
                        column: x => x.EnumAccesID,
                        principalSchema: "Fortigate",
                        principalTable: "EnumAcces",
                        principalColumn: "EnumAccesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessInterface_Interface_InterfaceID",
                        column: x => x.InterfaceID,
                        principalSchema: "Fortigate",
                        principalTable: "Interface",
                        principalColumn: "InterfaceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaticRoute",
                schema: "Fortigate",
                columns: table => new
                {
                    StaticRouteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterfaceID = table.Column<int>(nullable: false),
                    DestinationSubnet = table.Column<string>(nullable: true),
                    Gateway = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticRoute", x => x.StaticRouteID);
                    table.ForeignKey(
                        name: "FK_StaticRoute_Interface_InterfaceID",
                        column: x => x.InterfaceID,
                        principalSchema: "Fortigate",
                        principalTable: "Interface",
                        principalColumn: "InterfaceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ip4Policy",
                schema: "Fortigate",
                columns: table => new
                {
                    Ip4PolicyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceInterfaceID = table.Column<int>(nullable: true),
                    DestinationInterfaceID = table.Column<int>(nullable: true),
                    SourceAddress = table.Column<string>(nullable: true),
                    DestinationAddress = table.Column<string>(nullable: true),
                    ActionID = table.Column<int>(nullable: true),
                    NatID = table.Column<int>(nullable: true),
                    DnsFilter = table.Column<bool>(nullable: false),
                    AvFilter = table.Column<bool>(nullable: false),
                    AppFilter = table.Column<bool>(nullable: false),
                    SslFilter = table.Column<bool>(nullable: false),
                    WebFilter = table.Column<bool>(nullable: false),
                    IpsFilter = table.Column<bool>(nullable: false),
                    ProxyFilter = table.Column<bool>(nullable: false),
                    ConfigfileID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ip4Policy", x => x.Ip4PolicyID);
                    table.ForeignKey(
                        name: "FK_Ip4Policy_Action_ActionID",
                        column: x => x.ActionID,
                        principalSchema: "Fortigate",
                        principalTable: "Action",
                        principalColumn: "ActionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ip4Policy_Zone_DestinationInterfaceID",
                        column: x => x.DestinationInterfaceID,
                        principalSchema: "Fortigate",
                        principalTable: "Zone",
                        principalColumn: "ZoneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ip4Policy_Nat_NatID",
                        column: x => x.NatID,
                        principalSchema: "Fortigate",
                        principalTable: "Nat",
                        principalColumn: "NatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ip4Policy_Zone_SourceInterfaceID",
                        column: x => x.SourceInterfaceID,
                        principalSchema: "Fortigate",
                        principalTable: "Zone",
                        principalColumn: "ZoneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ip4PolicyService",
                schema: "Fortigate",
                columns: table => new
                {
                    Ip4PolicyServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceID = table.Column<int>(nullable: false),
                    Ip4PolicyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ip4PolicyService", x => x.Ip4PolicyServiceID);
                    table.ForeignKey(
                        name: "FK_Ip4PolicyService_Ip4Policy_Ip4PolicyID",
                        column: x => x.Ip4PolicyID,
                        principalSchema: "Fortigate",
                        principalTable: "Ip4Policy",
                        principalColumn: "Ip4PolicyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ip4PolicyService_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalSchema: "Fortigate",
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZoneInterface",
                schema: "Fortigate",
                columns: table => new
                {
                    ZoneInterfaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterfaceID = table.Column<int>(nullable: false),
                    ZoneID = table.Column<int>(nullable: false),
                    Ip4PolicyID = table.Column<int>(nullable: true)
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
                        name: "FK_ZoneInterface_Ip4Policy_Ip4PolicyID",
                        column: x => x.Ip4PolicyID,
                        principalSchema: "Fortigate",
                        principalTable: "Ip4Policy",
                        principalColumn: "Ip4PolicyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneInterface_Zone_ZoneID",
                        column: x => x.ZoneID,
                        principalSchema: "Fortigate",
                        principalTable: "Zone",
                        principalColumn: "ZoneID",
                        onDelete: ReferentialAction.Cascade);
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
                    ConfigFileID = table.Column<int>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_AccessInterface_EnumAccesID",
                schema: "Fortigate",
                table: "AccessInterface",
                column: "EnumAccesID");

            migrationBuilder.CreateIndex(
                name: "IX_AccessInterface_InterfaceID",
                schema: "Fortigate",
                table: "AccessInterface",
                column: "InterfaceID");

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
                name: "IX_Group_ConfigFileID",
                schema: "Fortigate",
                table: "Group",
                column: "ConfigFileID");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumModeID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumModeID");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumPhysicalID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumPhysicalID");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_EnumTypeID",
                schema: "Fortigate",
                table: "Interface",
                column: "EnumTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ip4Policy_ActionID",
                schema: "Fortigate",
                table: "Ip4Policy",
                column: "ActionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ip4Policy_ConfigfileID",
                schema: "Fortigate",
                table: "Ip4Policy",
                column: "ConfigfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Ip4Policy_DestinationInterfaceID",
                schema: "Fortigate",
                table: "Ip4Policy",
                column: "DestinationInterfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Ip4Policy_NatID",
                schema: "Fortigate",
                table: "Ip4Policy",
                column: "NatID");

            migrationBuilder.CreateIndex(
                name: "IX_Ip4Policy_SourceInterfaceID",
                schema: "Fortigate",
                table: "Ip4Policy",
                column: "SourceInterfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Ip4PolicyService_Ip4PolicyID",
                schema: "Fortigate",
                table: "Ip4PolicyService",
                column: "Ip4PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_Ip4PolicyService_ServiceID",
                schema: "Fortigate",
                table: "Ip4PolicyService",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_StaticRoute_InterfaceID",
                schema: "Fortigate",
                table: "StaticRoute",
                column: "InterfaceID");

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

            migrationBuilder.CreateIndex(
                name: "IX_ZoneInterface_InterfaceID",
                schema: "Fortigate",
                table: "ZoneInterface",
                column: "InterfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneInterface_Ip4PolicyID",
                schema: "Fortigate",
                table: "ZoneInterface",
                column: "Ip4PolicyID");

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
                name: "FK_Ip4Policy_ConfigFile_ConfigfileID",
                schema: "Fortigate",
                table: "Ip4Policy",
                column: "ConfigfileID",
                principalSchema: "Fortigate",
                principalTable: "ConfigFile",
                principalColumn: "ConfigfileID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Employee_Client_ClientID",
                schema: "Fortigate",
                table: "Employee",
                column: "ClientID",
                principalSchema: "Fortigate",
                principalTable: "Client",
                principalColumn: "ClientID",
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

            migrationBuilder.DropTable(
                name: "AccessInterface",
                schema: "Fortigate");

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
                name: "Ip4PolicyService",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "StaticRoute",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "UserGroup",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "VpnSetting",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "ZoneInterface",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "ZonePolicy",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "EnumAcces",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Service",
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

            migrationBuilder.DropTable(
                name: "Interface",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Ip4Policy",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "EnumMode",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "EnumPhysical",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "EnumType",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Action",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Zone",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Nat",
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
                name: "ConfigFile",
                schema: "Fortigate");

            migrationBuilder.DropTable(
                name: "Filter",
                schema: "Fortigate");
        }
    }
}
