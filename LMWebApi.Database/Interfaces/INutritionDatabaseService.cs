using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;

namespace LMWebApi.Database.Interfaces
{
    public interface INutritionDatabaseService
    {
        Task<IEnumerable<DailyNutrition>> GetAll();
        Task<IEnumerable<DailyNutrition>> Get(DateTime fromDate, DateTime toDate);
        Task<IEnumerable<DailyNutrition>> GetForDay(DateTime date);
        Task<DailyNutrition> Add(DailyNutrition dailyNutrition);
        Task Delete(string nutritionId);
    }
}