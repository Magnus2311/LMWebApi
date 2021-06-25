using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using LMWebApi.Helpers.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LMWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NutritionsController : ControllerBase
    {
        private readonly INutritionDatabaseService _nutritionDatabaseService;

        public NutritionsController(INutritionDatabaseService nutritionDatabaseService)
            => _nutritionDatabaseService = nutritionDatabaseService;

        [HttpGet]
        public async Task<IEnumerable<DailyNutrition>> GetAll()
            => await _nutritionDatabaseService.GetAll();

        [HttpGet("get-for-period")]
        public async Task<IEnumerable<DailyNutrition>> Get(DateTime fromDate, DateTime toDate)
            => await _nutritionDatabaseService.Get(fromDate, toDate);

        [HttpGet("get-for-day")]
        public async Task<IEnumerable<DailyNutrition>> GetForDay(DateTime date)
            => await _nutritionDatabaseService.GetForDay(date);

        [HttpPost]
        public async Task<DailyNutrition> Post(DailyNutrition dailyNutrition)
        {
            if (ModelState.IsValid)
            {
                await _nutritionDatabaseService.Add(dailyNutrition);
                return dailyNutrition;
            }
            throw new Exception();
        }

        [HttpDelete]
        public async Task Delete(string _nutritionId)
            => await _nutritionDatabaseService.Delete(_nutritionId);
    }
}
