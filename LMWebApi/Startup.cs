using LMWebApi.Database;
using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace LMWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //MSSQL Database
            services.AddDbContext<LMDbContext>();

            services.AddCors();
            services.AddControllers().AddNewtonsoftJson();

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var dbContext = app
            .ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope()
            .ServiceProvider
            .GetService<LMDbContext>())
            {
                dbContext.Database.Migrate();
            }
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductsDatabaseService, ProductsDatabaseService>();
            services.AddScoped<ICategoriesDatabaseService, CategoriesDatabaseService>();
        }
    }
}
