﻿using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return new LMDbContext().ShopItemFeedbacks.Include(sh => sh.User).Where(s => s.ShopItemId == shopItemId).OrderByDescending(a => a.Date);
        }

        public async Task Add(ShopItemFeedback shopItemFeedback)
        {
            shopItemFeedback.Date = DateTime.Now;
            var dbContext = new LMDbContext();
            await dbContext.ShopItemFeedbacks.AddAsync(shopItemFeedback);
            await dbContext.SaveChangesAsync();
            shopItemFeedback.ShopItem = dbContext.ShopItems.FirstOrDefault(s => s.Id == shopItemFeedback.ShopItemId);
            shopItemFeedback.User = dbContext.Users.FirstOrDefault(a => a.Id == shopItemFeedback.UserId);
            var feedbacks = dbContext.ShopItemFeedbacks.Where(sh => sh.ShopItemId == shopItemFeedback.ShopItemId);
            shopItemFeedback.ShopItem.Rating = feedbacks.Sum(a => a.Rating) / feedbacks.Count();
            await dbContext.SaveChangesAsync();
        }

        public async Task Add(List<ShopItemFeedback> shopItemFeedbacks)
        {
            foreach (var item in shopItemFeedbacks)
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
