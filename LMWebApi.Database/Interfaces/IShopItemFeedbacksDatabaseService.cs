using LMWebApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMWebApi.Database.Interfaces
{
    public interface IShopItemFeedbacksDatabaseService
    {
        IEnumerable<ShopItemFeedback> GetAllFeedbacks();
        IEnumerable<ShopItemFeedback> GetShopItemFeedbacks(int shopItemId);
        Task Add(ShopItemFeedback shopItemFeedback);
        Task Add(List<ShopItemFeedback> shopItemFeedbacks);
        Task Delete(int shopItemFeedbackId);
    }
}
