using RaspberryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RaspberryWebApp.DAL
{
    public class RaspContext : DbContext
    {

        public RaspContext() : base("RaspContext")
        {

        }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Relay> Relays { get; set; }
        public DbSet<RelayEvent> RelayEvents { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
