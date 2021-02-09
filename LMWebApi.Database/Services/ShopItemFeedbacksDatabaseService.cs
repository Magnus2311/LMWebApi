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
    public class ShopItemFeedbacksDatabaseService : IShopItemFeedbacksDatabaseService
    {
        public IEnumerable<ShopItemFeedback> GetAllFeedbacks()
        {
            return new LMDbContext().ShopItemFeedbacks;
        }

        public IEnumerable<ShopItemFeedback> GetShopItemFeedbacks(int shopItemId)
        {
            return new LMDbContext().ShopItemFeedbacks.Include(sh => sh.User).Where(s => s.ShopItemId == shopItemId).OrderByDescending(a=>a.Date);
        }

        public async Task Add(ShopItemFeedback shopItemFeedback)
        {
            shopItemFeedback.Date = DateTime.Now;
            var dbContext = new LMDbContext();
            await dbContext.ShopItemFeedbacks.AddAsync(shopItemFeedback);
            await dbContext.SaveChangesAsync();
            shopItemFeedback.User = dbContext.Users.FirstOrDefault(a =>a.Id == shopItemFeedback.UserId);
        }

        public async Task Add(List<ShopItemFeedback> shopItemFeedbacks)
        {
            foreach(var item in shopItemFeedbacks)
                item.Date = DateTime.Now;

            var dbContext = new LMDbContext();
            await dbContext.ShopItemFeedbacks.AddRangeAsync(shopItemFeedbacks);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int shopItemFeedbackId)
        {
            var dbContext = new LMDbContext();
            var shopItemFeedback = await dbContext.ShopItemFeedbacks.FirstOrDefaultAsync(c => c.Id == shopItemFeedbackId);
            dbContext.Remove(shopItemFeedback);
            await dbContext.SaveChangesAsync();
        }
    }
}
