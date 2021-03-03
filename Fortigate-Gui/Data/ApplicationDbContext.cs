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
        public DbSet<EnumAlias> EnumAliases { get; set; }
        public DbSet<EnumMode> EnumModes { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<Interface> Interfaces { get; set; }
        public DbSet<Ip4Policy> Ip4Policies { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VPNtunnel> VPNtunnels { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ZoneInterface> ZoneInterfaces { get; set; }
        public DbSet<ZonePolicy> ZonePolicies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.HasDefaultSchema("Fortigate");

            modelbuilder.Entity<Client>().ToTable("Client");
            modelbuilder.Entity<ConfigFile>().ToTable("ConfigFile");
            modelbuilder.Entity<Employee>().ToTable("Employee");
            modelbuilder.Entity<EnumAcces>().ToTable("EnumAcces");
            modelbuilder.Entity<EnumAlias>().ToTable("EnumAlias");
            modelbuilder.Entity<EnumMode>().ToTable("EnumMode");
            modelbuilder.Entity<Filter>().ToTable("Filter");
            modelbuilder.Entity<Interface>().ToTable("Interface");
            modelbuilder.Entity<Ip4Policy>().ToTable("Ip4Policy");
            modelbuilder.Entity<Setting>().ToTable("Setting");
            modelbuilder.Entity<Customer>().ToTable("Customer");
            modelbuilder.Entity<VPNtunnel>().ToTable("VPNtunnel");
            modelbuilder.Entity<Zone>().ToTable("Zone");
            modelbuilder.Entity<ZoneInterface>().ToTable("ZoneInterface");
            modelbuilder.Entity<ZonePolicy>().ToTable("ZonePolicy");

        }
    }
}
