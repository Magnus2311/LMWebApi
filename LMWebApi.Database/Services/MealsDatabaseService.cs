using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMWebApi.Database.Services
{
    public class MealsDatabaseService : IMealsDatabaseService
    {
        public async Task Add(Meal meal)
        {
            var dbContext = new LMDbContext();
            await dbContext.AddAsync<Meal>(meal);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(string mealId)
        {
            var dbContext = new LMDbContext();
            var meal = await dbContext.Meals.FirstOrDefaultAsync(m => m.Id == mealId);
            dbContext.Meals.Remove(meal);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<Meal> GetAll()
        {
            var dbContext = new LMDbContext();
            return dbContext.Meals;
        }

        public async Task Update(Meal meal)
        {
            var dbContext = new LMDbContext();
            var mealToUpdate = await dbContext.Meals.FirstOrDefaultAsync(m => m.Id == meal.Id);
            mealToUpdate = meal;
            await dbContext.SaveChangesAsync();
        }
    }
}