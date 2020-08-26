using LMWebApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace LMWebApi.Database
{
    public class LMDbContext : DbContext
    {
        public LMDbContext(DbContextOptions<LMDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}
