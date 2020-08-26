namespace LMWebApi.Database
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System;

    public class LMDbContextFactory : IDesignTimeDbContextFactory<LMDbContext>
    {
        public LMDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                //.AddJsonFile("appsettings.Development.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<LMDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=LifeMode;User Id=sa;Password=Micr0!nvest;");

            return new LMDbContext(optionsBuilder.Options);
        }
    }
}