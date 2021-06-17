using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;

namespace LMWebApi.Database.Interfaces
{
    public interface INutritionDatabaseService
    {
        Task<IEnumerable<DailyNutrition>> GetAll(User user);
        Task<IEnumerable<DailyNutrition>> Get(User user, DateTime fromDate, DateTime toDate);
        Task<DailyNutrition> Add(DailyNutrition dailyNutrition);
        Task Delete(User user, string nutritionId);
    }
}