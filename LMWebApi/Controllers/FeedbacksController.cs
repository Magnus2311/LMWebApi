using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IShopItemFeedbacksDatabaseService shopItemFeedbacksDatabaseService;
        public FeedbacksController(IShopItemFeedbacksDatabaseService _shopItemFeedbacksDatabaseService)
        {
            shopItemFeedbacksDatabaseService = _shopItemFeedbacksDatabaseService;
        }

        [HttpGet("getByShopItemId")]
        public IEnumerable<ShopItemFeedback> GetshopItemFeedbacks(int shopItemId)
            => shopItemFeedbacksDatabaseService.GetShopItemFeedbacks(shopItemId);

        [HttpPost]
        public async Task<ShopItemFeedback> Post(ShopItemFeedback shopItemFeedback)
        {
            if (ModelState.IsValid)
            {
                await shopItemFeedbacksDatabaseService.Add(shopItemFeedback);
                return shopItemFeedback;
            }
            throw new Exception();
        }

        [HttpDelete]
        public async Task DeleteShopItemFeedback(string shopItemFeedbackId)
            => await shopItemFeedbacksDatabaseService.Delete(int.Parse(shopItemFeedbackId));
    }
}
