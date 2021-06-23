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
    public class NutritionController : ControllerBase
    {
        private readonly INutritionDatabaseService _nutritionDatabaseService;
        private readonly IUserDatabaseService _userDatabaseService;

        public NutritionController(INutritionDatabaseService nutritionDatabaseService,
            IUserDatabaseService userDatabaseService)
        {
            _nutritionDatabaseService = nutritionDatabaseService;
            _userDatabaseService = userDatabaseService;
        }

        [HttpGet]
        public async Task<IEnumerable<DailyNutrition>> GetAll()
        {
            return await _nutritionDatabaseService.GetAll();
        }

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
        {
            await _nutritionDatabaseService.Delete(_nutritionId);
        }
    }
}
