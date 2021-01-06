using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopDatabaseService shopDatabaseService;
        public ShopController(IShopDatabaseService _shopDatabaseService)
        {
            shopDatabaseService = _shopDatabaseService;
        }

        [HttpGet]
        public IEnumerable<ShopCategory> Get()
        {
            return shopDatabaseService.GetAllCategories();
        }


        [HttpPost]
        public async Task<ShopCategory> Post(ShopCategory shopCategory)
        {
            if (ModelState.IsValid)
            {
                await shopDatabaseService.Add(shopCategory);
                return shopCategory;
            }
            throw new Exception();
        }

        [HttpPut]
        public async Task Put(ShopCategory shopCategory) => await shopDatabaseService.Update(shopCategory);

        [HttpDelete]
        public async Task Delete(string shopCategoryId) => await shopDatabaseService.Delete(int.Parse(shopCategoryId));
    }
}
