using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMWebApi.Database.Services
{
    public class ShopDatabaseService : IShopDatabaseService
    {
        public IEnumerable<ShopCategory> GetAllCategories()
        {
            return new LMDbContext().ShopCategories;
        }

        public async Task Add(ShopCategory shopCategory)
        {
            var dbContext = new LMDbContext();
            await dbContext.ShopCategories.AddAsync(shopCategory);
            await dbContext.SaveChangesAsync();
        }

        public async Task Add(List<ShopCategory> shopCategories)
        {
            var dbContext = new LMDbContext();
            await dbContext.ShopCategories.AddRangeAsync(shopCategories);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int shopCategoryId)
        {
            var dbContext = new LMDbContext();
            var shopCategory = await dbContext.ShopCategories.FirstOrDefaultAsync(c => c.Id == shopCategoryId);
            dbContext.Remove(shopCategory);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(ShopCategory shopCategory)
        {
            var dbContext = new LMDbContext();
            var shopCategoryToUpdate = await dbContext.ShopCategories.FirstOrDefaultAsync(c => c.Id == shopCategory.Id);
            shopCategoryToUpdate = shopCategory;
            await dbContext.SaveChangesAsync();
        }
    }
}
