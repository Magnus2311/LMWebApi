using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LMWebApi.Common.Models.Database;
using LMWebApi.Common.Models.DTOs;
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
        private readonly IMapper _mapper;

        public NutritionsController(INutritionDatabaseService nutritionDatabaseService,
            IMapper mapper)
        {
            _nutritionDatabaseService = nutritionDatabaseService;
            _mapper = mapper;
        }

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
        public async Task<DailyNutrition> Post(DailyNutritionDTO dailyNutritionDTO)
        {
            var dailyNutrition = _mapper.Map<DailyNutrition>(dailyNutritionDTO);
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
