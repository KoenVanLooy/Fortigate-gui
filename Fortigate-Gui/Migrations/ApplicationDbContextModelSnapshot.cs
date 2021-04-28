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
                .HasAnnotation("ProductVersion", "3.1.13")
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

            modelBuilder.Entity("Fortigate_Gui.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("FactoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.ConfigFile", b =>
                {
                    b.Property<int>("ConfigfileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilterID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConfigfileID");

                    b.HasIndex("ClientID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("FilterID");

                    b.ToTable("ConfigFile");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<int?>("ConfigfileID")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerID");

                    b.HasIndex("ConfigfileID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("ClientID");

                    b.ToTable("Employee");
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

            modelBuilder.Entity("Fortigate_Gui.Models.Filter", b =>
                {
                    b.Property<int>("FilterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfigFilter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilterID");

                    b.ToTable("Filter");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.FirewallAddress", b =>
                {
                    b.Property<int>("FirewallAddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssociatedZone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subnet")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("User");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConfigFileID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupID");

                    b.HasIndex("ConfigFileID");

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

                    b.Property<int>("EnumAccesID")
                        .HasColumnType("int");

                    b.Property<int>("EnumModeID")
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("SecondaryIp")
                        .HasColumnType("bit");

                    b.Property<string>("Subnet")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Vdom")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("InterfaceID");

                    b.HasIndex("EnumAccesID");

                    b.HasIndex("EnumModeID");

                    b.ToTable("Interface");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Ip4Policy", b =>
                {
                    b.Property<int>("Ip4PolicyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConfigfileID")
                        .HasColumnType("int");

                    b.Property<string>("DestinationAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationInterface")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceInterface")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ip4PolicyID");

                    b.HasIndex("ConfigfileID");

                    b.ToTable("Ip4Policy");
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

                    b.Property<int?>("ConfigFileID")
                        .HasColumnType("int");

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

                    b.HasIndex("ConfigFileID");

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

                    b.Property<int>("ZoneID")
                        .HasColumnType("int");

                    b.HasKey("ZoneInterfaceID");

                    b.HasIndex("InterfaceID");

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

            modelBuilder.Entity("Fortigate_Gui.Models.Client", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.ConfigFile", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.Customer", null)
                        .WithMany("Configfiles")
                        .HasForeignKey("CustomerID");

                    b.HasOne("Fortigate_Gui.Models.Filter", "Filter")
                        .WithMany()
                        .HasForeignKey("FilterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Customer", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.ConfigFile", "Configfile")
                        .WithMany()
                        .HasForeignKey("ConfigfileID");

                    b.HasOne("Fortigate_Gui.Areas.Identity.Data.CustomUser", "CustomUser")
                        .WithOne("Customer")
                        .HasForeignKey("Fortigate_Gui.Models.Customer", "UserID");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Employee", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Client", null)
                        .WithMany("Employees")
                        .HasForeignKey("ClientID");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Group", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.ConfigFile", "configFile")
                        .WithMany("Groups")
                        .HasForeignKey("ConfigFileID");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Interface", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.EnumAcces", "EnumAcces")
                        .WithMany()
                        .HasForeignKey("EnumAccesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.EnumMode", "EnumMode")
                        .WithMany()
                        .HasForeignKey("EnumModeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fortigate_Gui.Models.Ip4Policy", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.ConfigFile", null)
                        .WithMany("Ip4Policies")
                        .HasForeignKey("ConfigfileID");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.UserGroup", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.FortiUser", "fortiUser")
                        .WithMany("userGroups")
                        .HasForeignKey("FortiUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.Group", "group")
                        .WithMany("userGroups")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fortigate_Gui.Models.VpnPortal", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.ConfigFile", "configFile")
                        .WithMany("VpnPortals")
                        .HasForeignKey("ConfigFileID");
                });

            modelBuilder.Entity("Fortigate_Gui.Models.VpnSetting", b =>
                {
                    b.HasOne("Fortigate_Gui.Models.Group", "group")
                        .WithMany()
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fortigate_Gui.Models.VpnPortal", "vpnPortal")
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
