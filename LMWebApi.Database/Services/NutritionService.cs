using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMWebApi.Database.Services
{
    public class NutritionDatabaseService : INutritionDatabaseService
    {
        public async Task<DailyNutrition> Add(DailyNutrition dailyNutrition)
        {
            var dbContext = new LMDbContext();
            await dbContext.DailyNutritions.AddAsync(dailyNutrition);
            await dbContext.SaveChangesAsync();
            return dailyNutrition;
        }

        public async Task<IEnumerable<DailyNutrition>> Get(User user, DateTime fromDate, DateTime toDate) =>
             await new LMDbContext()
                .DailyNutritions
                .Where(dn => dn.UserId == user.Id
                            && dn.Date >= fromDate.Date
                            && dn.Date <= toDate.Date)
                .ToListAsync();

        public async Task<IEnumerable<DailyNutrition>> GetAll(User user) =>
             await new LMDbContext()
                .DailyNutritions
                .Where(dn => dn.UserId == user.Id)
                .ToListAsync();

        public async Task Delete(User user, string nutritionId)
        {
            if (user.DailyNutritions.Any(dn => dn.Id == nutritionId))
            {
                var context = new LMDbContext();
                var dailyNutrition = await context.DailyNutritions.FirstOrDefaultAsync(dn => dn.Id == nutritionId);
                context.DailyNutritions.Remove(dailyNutrition);
                await context.SaveChangesAsync();
            }
        }
    }
}