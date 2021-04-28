using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealsController : ControllerBase
    {
        private readonly IMealsDatabaseService _mealsDbService;

        public MealsController(IMealsDatabaseService mealsDbService)
            => _mealsDbService = mealsDbService;

        [HttpGet]
        public IEnumerable<Meal> Get() => _mealsDbService.GetAll();
        [HttpPost]
        public async Task Add(Meal meal) => await _mealsDbService.Add(meal);
        [HttpDelete]
        public async Task Delete(string mealId) => await _mealsDbService.Delete(mealId);
        [HttpPut]
        public async Task Update(Meal meal) => await _mealsDbService.Update(meal);
    }
}