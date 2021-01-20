using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesDatabaseService _categoriesDbService;

        public CategoriesController(ICategoriesDatabaseService categoriesDbService)
            => _categoriesDbService = categoriesDbService;

        [HttpGet]
        public IEnumerable<Category> Get() => _categoriesDbService.GetAll();

        [HttpPost]
        public async Task<Category> Post(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoriesDbService.Add(category);
                return category;
            }
            throw new Exception();
        }

        [HttpPut]
        public async Task Put(Category category) => await _categoriesDbService.Update(category);

        [HttpDelete]
        public async Task Delete(string categoryId) => await _categoriesDbService.Delete(categoryId);
    }
}
