using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using LMWebApi.Common.Models.Global;

namespace LMWebApi.Database.Services
{
    public class NutritionDatabaseService : INutritionDatabaseService
    {
        public async Task<DailyNutrition> Add(DailyNutrition dailyNutrition)
        {
            dailyNutrition.User = GlobalHelpers.CurrentUser;
            var dbContext = new LMDbContext();
            await dbContext.DailyNutritions.AddAsync(dailyNutrition);
            await dbContext.SaveChangesAsync();
            return dailyNutrition;
        }

        public async Task<IEnumerable<DailyNutrition>> Get(DateTime fromDate, DateTime toDate) =>
             await new LMDbContext()
                .DailyNutritions
                .Where(dn => dn.UserId == GlobalHelpers.CurrentUser.Id
                            && dn.Date >= fromDate.Date
                            && dn.Date <= toDate.Date)
                .ToListAsync();

        public async Task<IEnumerable<DailyNutrition>> GetAll() =>
             await new LMDbContext()
                .DailyNutritions
                .Where(dn => dn.UserId == GlobalHelpers.CurrentUser.Id)
                .ToListAsync();

        public async Task Delete(string nutritionId)
        {
            if (GlobalHelpers.CurrentUser.DailyNutritions.Any(dn => dn.Id == nutritionId))
            {
                var context = new LMDbContext();
                var dailyNutrition = await context.DailyNutritions.FirstOrDefaultAsync(dn => dn.Id == nutritionId);
                context.DailyNutritions.Remove(dailyNutrition);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DailyNutrition>> GetForDay(DateTime date)
            => await new LMDbContext()
                .DailyNutritions
                .Where(dn => dn.UserId == GlobalHelpers.CurrentUser.Id
                            && dn.Date == date.Date)
                .ToListAsync();
    }
}