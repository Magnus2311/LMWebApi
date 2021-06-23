using System;
using LMWebApi.Common.Iterfaces;
using LMWebApi.Common.Services;
using LMWebApi.Database;
using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Services;
using LMWebApi.Emails.Interfaces;
using LMWebApi.Emails.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

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

            services.AddCors();

            //MSSQL Database
            services.AddDbContext<LMDbContext>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.SlidingExpiration = true;
                });

            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../../LifeMode/build";
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../../LifeMode";
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            app.UseCors(
                options => options.WithOrigins("https://localhost:44312/", "https://localhost:5001/").AllowAnyMethod()
            );

            var dbContext = new LMDbContext();
            dbContext.Database.Migrate();

        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductsDatabaseService, ProductsDatabaseService>();
            services.AddScoped<ICategoriesDatabaseService, CategoriesDatabaseService>();
            services.AddScoped<IShopDatabaseService, ShopDatabaseService>();
            services.AddScoped<IShopItemsDatabaseService, ShopItemsDatabaseService>();
            services.AddScoped<IBrandsDatabaseService, BrandsDatabaseService>();
            services.AddScoped<IUserDatabaseService, UserDatabaseService>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<IShopItemFeedbacksDatabaseService, ShopItemFeedbacksDatabaseService>();
            services.AddScoped<IEmailsService, GmailSmtpEmailsService>();
            services.AddScoped<ITokenizer, Tokenizer>();
            services.AddScoped<INutritionDatabaseService, NutritionDatabaseService>();
            services.AddScoped<IKnowledgeDatabaseService, KnowledgeDatabaseService>();
            services.AddScoped<IArticlesDatabaseService, ArticlesDatabaseService>();
        }
    }
}
