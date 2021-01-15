using EFCoreHW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreHW.Data
{
    public class HWDbContext : DbContext 
    {
        public HWDbContext()
        {

        }
        public HWDbContext(DbContextOptions<HWDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasOne(c => c.Category)
                        .WithMany(p => p.Products)
                        .HasForeignKey(k => k.CategoryId);
            modelBuilder.Entity<Category>()
                        .HasMany(p => p.Products)
                        .WithOne(c => c.Category)
                        .HasForeignKey(k => k.CategoryId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
