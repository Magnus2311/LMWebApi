using LMWebApi.Common.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace LMWebApi.Database
{
    public class LMDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DailyNutrition> DailyNutritions { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShopItemFeedback> ShopItemFeedbacks { get; set; }

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

            builder.Entity<ShopItem>()
               .HasOne(p => p.Brand)
               .WithMany(v => v.ShopItems)
               .HasForeignKey(v => v.BrandId);

            builder.Entity<ShopItemFeedback>()
                .HasOne(p => p.ShopItem)
                .WithMany(v => v.Feedbacks)
                .HasForeignKey(v => v.ShopItemId);

            builder.Entity<ShopItemFeedback>()
                .HasOne(p => p.User)
                .WithMany(v => v.ShopItemFeedbacks)
                .HasForeignKey(v => v.UserId);

            builder.Entity<DailyNutrition>()
                .HasOne(dn => dn.Product)
                .WithMany(p => p.DailyNutritions)
                .HasForeignKey(dn => dn.ProductId);

            builder.Entity<DailyNutrition>()
                .HasOne(dn => dn.User)
                .WithMany(p => p.DailyNutritions)
                .HasForeignKey(dn => dn.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseSqlServer("Server=.;Database=LifeMode;Integrated Security=True;");
        }
    }
}
