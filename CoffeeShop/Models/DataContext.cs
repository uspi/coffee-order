using Microsoft.EntityFrameworkCore;
using System;

namespace CoffeeShop.Models
{
    public class DataContext : DbContext
    {
        public DbSet<CoffeeOrder> Orders { get; set; }

        public DbSet<Coffee> Variations { get; set; }

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<CoffeeOrder>().ToTable("Orders");
            //builder.Ignore<CoffeeVarietyBase>();
            //builder.Entity<CoffeeVarietyBase>();

            //builder.Entity<Coffee>()
            //    .HasOne(o => o.CoffeeOrder)
            //    .WithMany(b => b.Coffees);

            //builder
            //    .Entity<Coffee>()
            //    .Property(v => v.CoffeeType)
            //    .HasConversion(
            //        p => (int)p, 
            //        p => (CoffeeType)p);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
