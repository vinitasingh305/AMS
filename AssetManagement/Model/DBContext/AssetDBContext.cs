using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Model.Mappings;

namespace AssetManagement.Model.DBContext
{
    public class AssetDBContext:DbContext
    {
        public AssetDBContext()
        {

        }

        public AssetDBContext(DbContextOptions<AssetDBContext> options)
      : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAsset> CustomerAssets { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = HMECL002395; Initial Catalog = AssetDb; User ID = sa;Password=system");
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssetMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CustomerAssetMap());
            modelBuilder.ApplyConfiguration(new Loginmap());
        }
    }
}
