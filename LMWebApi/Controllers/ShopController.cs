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
        private readonly IBrandsDatabaseService brandsDatabaseService;
        private readonly IShopItemsDatabaseService shopItemsDatabaseService;
        public ShopController(IShopDatabaseService _shopDatabaseService,IShopItemsDatabaseService _shopItemsDatabaseService,IBrandsDatabaseService _brandsDatabaseService)
        {
            shopDatabaseService = _shopDatabaseService;
            shopItemsDatabaseService = _shopItemsDatabaseService;
            brandsDatabaseService = _brandsDatabaseService;
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

        [HttpGet("shopItems")]
        public IEnumerable<ShopItem> GetShopItemsByCategory(int categoryId, int pageNumber)
        {
            var aaaaaaaaaa = shopItemsDatabaseService.GetShopItemsByCategory(categoryId, pageNumber);
            return aaaaaaaaaa;
        }

        [HttpPost("shopItems")]
        public async Task<ShopItem> Post(ShopItem shopItem)
        {
            if (ModelState.IsValid)
            {
                await shopItemsDatabaseService.Add(shopItem);
                return shopItem;
            }
            throw new Exception();
        }

        [HttpGet("brands")]
        public IEnumerable<Brand> GetShopBrands()
        {
            return brandsDatabaseService.GetAll();
        }
    }
}
