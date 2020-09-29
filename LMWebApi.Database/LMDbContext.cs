using System.Net.NetworkInformation;
using LMWebApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace LMWebApi.Database
{
    public class LMDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasOne(c => c.Parent)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Product>()
                .HasOne(p => p.ProductInfo)
                .WithOne(pi => pi.Product)
                .HasForeignKey<ProductInfo>(pi => pi.ProductId);

            builder.Entity<ProductInfo>()
                .HasOne(p => p.AminoAcids)
                .WithOne(aa => aa.ProductInfo)
                .HasForeignKey<AminoAcids>(aa => aa.ProductInfoId);

            builder.Entity<ProductInfo>()
                .HasOne(p => p.Carbohydrates)
                .WithOne(c => c.ProductInfo)
                .HasForeignKey<Carbohydrates>(c => c.ProductInfoId);

            builder.Entity<ProductInfo>()
                .HasOne(p => p.Fats)
                .WithOne(f => f.ProductInfo)
                .HasForeignKey<Fats>(f => f.ProductInfoId);

            builder.Entity<ProductInfo>()
                .HasOne(p => p.Minerals)
                .WithOne(m => m.ProductInfo)
                .HasForeignKey<Minerals>(m => m.ProductInfoId);

            builder.Entity<ProductInfo>()
                .HasOne(p => p.Others)
                .WithOne(o => o.ProductInfo)
                .HasForeignKey<Others>(o => o.ProductInfoId);

            builder.Entity<ProductInfo>()
                .HasOne(p => p.Sterols)
                .WithOne(s => s.ProductInfo)
                .HasForeignKey<Sterols>(s => s.ProductInfoId);

            builder.Entity<ProductInfo>()
                .HasOne(p => p.Vitamins)
                .WithOne(v => v.ProductInfo)
                .HasForeignKey<Vitamins>(v => v.ProductInfoId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseSqlServer("Server=.;Database=LifeMode;User Id=sa;Password=Micr0!nvest;");
        }
    }
}
