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

            builder.Entity<Product>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder
                .Entity<Category>()
                .HasOne(c => c.Parent)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseSqlServer("Server=.;Database=LifeMode;User Id=sa;Password=Micr0!nvest;");
        }
    }
}
