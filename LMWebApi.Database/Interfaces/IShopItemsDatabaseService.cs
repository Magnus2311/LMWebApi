using LMWebApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMWebApi.Database.Interfaces
{
    public interface IShopItemsDatabaseService
    {
        IEnumerable<ShopItem> GetShopItemsByCategory(int categoryId,int pageNumber);
        Task Add(ShopItem shopItem);
        Task Add(List<ShopItem> shopItems);
        Task Delete(int shopItemId);
        Task Update(ShopItem shopItem);
    }
}
