using IlirGashijstree.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace IlirGashijstree.Data
{
    public class Context : DbContext
    {
        public Context()
            : base("DbString")
        {
        }
        public DbSet<CommodityRoots> CommodityRoots { get; set; }
        public DbSet<CommodityChapters> CommodityChapters { get; set; }
   
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
}
}