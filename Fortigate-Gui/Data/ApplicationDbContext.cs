using System;
using System.Collections.Generic;
using System.Text;
using Fortigate_Gui.Areas.Identity.Data;
using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fortigate_Gui.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ConfigFile> ConfigFiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EnumAcces> EnumAcces { get; set; }
        public DbSet<EnumMode> EnumModes { get; set; }
        public DbSet<EnumType> EnumTypes { get; set; }
        public DbSet<EnumPhysical> EnumPhysicals { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<Interface> Interfaces { get; set; }
        public DbSet<Ip4Policy> Ip4Policies { get; set; }
        public DbSet<VpnPortal> VpnPortals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VpnSetting> VpnSettings { get; set; }
        public DbSet<FortiUser> FortiUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ZoneInterface> ZoneInterfaces { get; set; }
        public DbSet<ZonePolicy> ZonePolicies { get; set; }
        public DbSet<FirewallAddress> FirewallAddresses { get; set; }

        public DbSet<Ip4PolicyService> Ip4PolicyServices { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Models.Action> Actions { get; set; }

        public DbSet<Nat> Nat { get; set; }

        public DbSet<StaticRoute> StaticRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.HasDefaultSchema("Fortigate");

            modelbuilder.Entity<Client>().ToTable("Client");
            modelbuilder.Entity<ConfigFile>().ToTable("ConfigFile");
            modelbuilder.Entity<Employee>().ToTable("Employee");
            modelbuilder.Entity<EnumAcces>().ToTable("EnumAcces");
            modelbuilder.Entity<EnumMode>().ToTable("EnumMode");
            modelbuilder.Entity<Filter>().ToTable("Filter");
            modelbuilder.Entity<Interface>().ToTable("Interface");
            modelbuilder.Entity<Ip4Policy>().ToTable("Ip4Policy");
            modelbuilder.Entity<VpnSetting>().ToTable("VpnSetting");
            modelbuilder.Entity<Customer>().ToTable("Customer");
            modelbuilder.Entity<VpnPortal>().ToTable("VpnPortal");
            modelbuilder.Entity<Zone>().ToTable("Zone");
            modelbuilder.Entity<ZoneInterface>().ToTable("ZoneInterface");
            modelbuilder.Entity<ZonePolicy>().ToTable("ZonePolicy");
            modelbuilder.Entity<FirewallAddress>().ToTable("FirewallAddress");
            modelbuilder.Entity<FortiUser>().ToTable("User");
            modelbuilder.Entity<Group>().ToTable("Group");
            modelbuilder.Entity<UserGroup>().ToTable("UserGroup");
            modelbuilder.Entity<EnumType>().ToTable("EnumType");
            modelbuilder.Entity<EnumPhysical>().ToTable("EnumPhysical");
            modelbuilder.Entity<Service>().ToTable("Service");
            modelbuilder.Entity<Ip4PolicyService>().ToTable("Ip4PolicyService");
            modelbuilder.Entity<Models.Action>().ToTable("Action");
            modelbuilder.Entity<Nat>().ToTable("Nat");
            modelbuilder.Entity<StaticRoute>().ToTable("StaticRoute");

        }
    }
}
