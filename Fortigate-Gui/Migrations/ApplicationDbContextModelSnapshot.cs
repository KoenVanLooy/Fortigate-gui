﻿// <auto-generated />
using System;
using Fortigate_Gui.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fortigate_Gui.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Fortigate")
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fortigate_Gui.Areas.Identity.Data.CustomUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.AccessInterface", b =>
                {
                    b.Property<int>("AccessInterfaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnumAccesID")
                        .HasColumnType("int");

                    b.Property<int>("InterfaceID")
                        .HasColumnType("int");

                    b.HasKey("AccessInterfaceID");

                    b.HasIndex("EnumAccesID");

                    b.HasIndex("InterfaceID");

                    b.ToTable("AccessInterface");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Action", b =>
                {
                    b.Property<int>("ActionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActionID");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.EnumAcces", b =>
                {
                    b.Property<int>("EnumAccesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnumAccesID");

                    b.ToTable("EnumAcces");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.EnumMode", b =>
                {
                    b.Property<int>("EnumModeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnumModeID");

                    b.ToTable("EnumMode");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.EnumPhysical", b =>
                {
                    b.Property<int>("EnumPhysicalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnumPhysicalID");

                    b.ToTable("EnumPhysical");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.EnumType", b =>
                {
                    b.Property<int>("EnumTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnumTypeID");

                    b.ToTable("EnumType");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.FirewallAddress", b =>
                {
                    b.Property<int>("FirewallAddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssociatedZone")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<string>("Subnet")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.HasKey("FirewallAddressID");

                    b.ToTable("FirewallAddress");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.FortiUser", b =>
                {
                    b.Property<int>("FortiUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FortiUserID");

                    b.ToTable("FortiUser");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupID");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Interface", b =>
                {
                    b.Property<int>("InterfaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("EnumModeID")
                        .HasColumnType("int");

                    b.Property<int?>("EnumPhysicalID")
                        .HasColumnType("int");

                    b.Property<int>("EnumTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subnet")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("VlanId")
                        .HasColumnType("int");

                    b.Property<string>("VlanInterface")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterfaceID");

                    b.HasIndex("EnumModeID");

                    b.HasIndex("EnumPhysicalID");

                    b.HasIndex("EnumTypeID");

                    b.ToTable("Interface");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Ip4Policy", b =>
                {
                    b.Property<int>("Ip4PolicyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActionID")
                        .HasColumnType("int");

                    b.Property<bool>("AppFilter")
                        .HasColumnType("bit");

                    b.Property<bool>("AvFilter")
                        .HasColumnType("bit");

                    b.Property<string>("DestinationAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DestinationInterfaceID")
                        .HasColumnType("int");

                    b.Property<bool>("DnsFilter")
                        .HasColumnType("bit");

                    b.Property<bool>("IpsFilter")
                        .HasColumnType("bit");

                    b.Property<int?>("NatID")
                        .HasColumnType("int");

                    b.Property<bool>("ProxyFilter")
                        .HasColumnType("bit");

                    b.Property<string>("SourceAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SourceInterfaceID")
                        .HasColumnType("int");

                    b.Property<bool>("SslFilter")
                        .HasColumnType("bit");

                    b.Property<bool>("WebFilter")
                        .HasColumnType("bit");

                    b.HasKey("Ip4PolicyID");

                    b.HasIndex("ActionID");

                    b.HasIndex("DestinationInterfaceID");

                    b.HasIndex("NatID");

                    b.HasIndex("SourceInterfaceID");

                    b.ToTable("Ip4Policy");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Ip4PolicyService", b =>
                {
                    b.Property<int>("Ip4PolicyServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ip4PolicyID")
                        .HasColumnType("int");

                    b.Property<int>("ServiceID")
                        .HasColumnType("int");

                    b.HasKey("Ip4PolicyServiceID");

                    b.HasIndex("Ip4PolicyID");

                    b.HasIndex("ServiceID");

                    b.ToTable("Ip4PolicyService");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Nat", b =>
                {
                    b.Property<int>("NatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NatID");

                    b.ToTable("Nat");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.StaticRoute", b =>
                {
                    b.Property<int>("StaticRouteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DestinationSubnet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gateway")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InterfaceID")
                        .HasColumnType("int");

                    b.HasKey("StaticRouteID");

                    b.HasIndex("InterfaceID");

                    b.ToTable("StaticRoute");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.UserGroup", b =>
                {
                    b.Property<int>("UserGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FortiUserID")
                        .HasColumnType("int");

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.HasKey("UserGroupID");

                    b.HasIndex("FortiUserID");

                    b.HasIndex("GroupID");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.VpnPortal", b =>
                {
                    b.Property<int>("VpnPortalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AutoConnect")
                        .HasColumnType("bit");

                    b.Property<string>("IpPool")
                        .IsRequired()
                        .HasColumnType("nvarchar(79)")
                        .HasMaxLength(79);

                    b.Property<bool>("KeepAlive")
                        .HasColumnType("bit");

                    b.Property<string>("PortalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<bool>("SavePassword")
                        .HasColumnType("bit");

                    b.Property<bool>("SplitTunneling")
                        .HasColumnType("bit");

                    b.Property<string>("SplitTunnelingRoute")
                        .HasColumnType("nvarchar(79)")
                        .HasMaxLength(79);

                    b.Property<bool>("TunnelMode")
                        .HasColumnType("bit");

                    b.Property<bool>("WebMode")
                        .HasColumnType("bit");

                    b.HasKey("VpnPortalID");

                    b.ToTable("VpnPortal");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.VpnSetting", b =>
                {
                    b.Property<int>("VpnSettingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DefaultPort")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("ServerCert")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<string>("SourceAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(79)")
                        .HasMaxLength(79);

                    b.Property<string>("SourceAddressV6")
                        .IsRequired()
                        .HasColumnType("nvarchar(79)")
                        .HasMaxLength(79);

                    b.Property<string>("SourceInterface")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<string>("TunnelIpPool")
                        .IsRequired()
                        .HasColumnType("nvarchar(79)")
                        .HasMaxLength(79);

                    b.Property<string>("TunnelIpv6Pool")
                        .IsRequired()
                        .HasColumnType("nvarchar(79)")
                        .HasMaxLength(79);

                    b.Property<int?>("VpnPortalID")
                        .HasColumnType("int");

                    b.HasKey("VpnSettingID");

                    b.HasIndex("GroupID");

                    b.HasIndex("VpnPortalID");

                    b.ToTable("VpnSetting");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Zone", b =>
                {
                    b.Property<int>("ZoneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZoneID");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.ZoneInterface", b =>
                {
                    b.Property<int>("ZoneInterfaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterfaceID")
                        .HasColumnType("int");

                    b.Property<int?>("Ip4PolicyID")
                        .HasColumnType("int");

                    b.Property<int>("ZoneID")
                        .HasColumnType("int");

                    b.HasKey("ZoneInterfaceID");

                    b.HasIndex("InterfaceID");

                    b.HasIndex("Ip4PolicyID");

                    b.HasIndex("ZoneID");

                    b.ToTable("ZoneInterface");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.ZonePolicy", b =>
                {
                    b.Property<int>("ZonePolicyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ip4PolicyID")
                        .HasColumnType("int");

                    b.Property<int>("ZoneID")
                        .HasColumnType("int");

                    b.HasKey("ZonePolicyID");

                    b.HasIndex("Ip4PolicyID");

                    b.HasIndex("ZoneID");

                    b.ToTable("ZonePolicy");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.AccessInterface", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.EnumAcces", "EnumAcces")
                        .WithMany()
                        .HasForeignKey("EnumAccesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.Interface", "Interface")
                        .WithMany("AccessInterfaces")
                        .HasForeignKey("InterfaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Customer", b =>
                {
                    b.HasOne("Fortigate_Gui.Areas.Identity.Data.CustomUser", "CustomUser")
                        .WithOne("Customer")
                        .HasForeignKey("Fortigate_Gui.Models.Customer", "UserID");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Interface", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.EnumMode", "EnumMode")
                        .WithMany()
                        .HasForeignKey("EnumModeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.EnumPhysical", "EnumPhysical")
                        .WithMany()
                        .HasForeignKey("EnumPhysicalID");

                    b.HasOne("Fortigate_Gui.Models.EnumType", "EnumType")
                        .WithMany()
                        .HasForeignKey("EnumTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Ip4Policy", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionID");

                    b.HasOne("Fortigate_Gui.Models.Zone", "DestinationInterface")
                        .WithMany()
                        .HasForeignKey("DestinationInterfaceID");

                    b.HasOne("Fortigate_Gui.Models.Nat", "Nat")
                        .WithMany()
                        .HasForeignKey("NatID");

                    b.HasOne("Fortigate_Gui.Models.Zone", "SourceInterface")
                        .WithMany()
                        .HasForeignKey("SourceInterfaceID");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Ip4PolicyService", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Ip4Policy", "Ip4Policy")
                        .WithMany("Ip4PolicyServices")
                        .HasForeignKey("Ip4PolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.Service", "Service")
                        .WithMany("Ip4PolicyServices")
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fortigate_Gui.Models.StaticRoute", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Interface", "Interface")
                        .WithMany()
                        .HasForeignKey("InterfaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fortigate_Gui.Models.UserGroup", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.FortiUser", "FortiUser")
                        .WithMany("UserGroups")
                        .HasForeignKey("FortiUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fortigate_Gui.Models.VpnSetting", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.VpnPortal", "VpnPortal")
                        .WithMany()
                        .HasForeignKey("VpnPortalID");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.ZoneInterface", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Interface", "Interface")
                        .WithMany()
                        .HasForeignKey("InterfaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.Ip4Policy", null)
                        .WithMany("ZoneInterfaces")
                        .HasForeignKey("Ip4PolicyID");

                    b.HasOne("Fortigate_Gui.Models.Zone", "Zone")
                        .WithMany("ZoneInterfaces")
                        .HasForeignKey("ZoneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fortigate_Gui.Models.ZonePolicy", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Ip4Policy", "Ip4Policy")
                        .WithMany()
                        .HasForeignKey("Ip4PolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.Zone", "Zone")
                        .WithMany()
                        .HasForeignKey("ZoneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Fortigate_Gui.Areas.Identity.Data.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Fortigate_Gui.Areas.Identity.Data.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Areas.Identity.Data.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Fortigate_Gui.Areas.Identity.Data.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
