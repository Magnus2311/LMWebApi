using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMWebApi.Database.Services
{
    public class ShopItemsDatabaseService : IShopItemsDatabaseService
    {
        public async Task Add(ShopItem shopItem)
        {
            var dbContext = new LMDbContext();
            await dbContext.ShopItems.AddAsync(shopItem);
            await dbContext.SaveChangesAsync();
        }

        public async Task Add(List<ShopItem> shopItems)
        {
            var dbContext = new LMDbContext();
            await dbContext.ShopItems.AddRangeAsync(shopItems);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int shopItemId)
        {
            var dbContext = new LMDbContext();
            var shopItem = await dbContext.ShopItems.FirstOrDefaultAsync(c => c.Id == shopItemId);
            dbContext.Remove(shopItem);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(ShopItem shopItem)
        {
            var dbContext = new LMDbContext();
            var shopItemToUpdate = await dbContext.ShopItems.FirstOrDefaultAsync(c => c.Id == shopItem.Id);
            shopItemToUpdate = shopItem;
            await dbContext.SaveChangesAsync();
        }
        public IEnumerable<ShopItem> GetShopItemsByCategory(int categoryId, int pageNumber)
        {
            return new LMDbContext().ShopItems
                                    ?.Where(s => s.ShopCategoryId == categoryId)
                                    .Take(pageNumber * 30); ;
        }
    }
}
