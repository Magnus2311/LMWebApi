using LMWebApi.Common.Models.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMWebApi.Database.Interfaces
{
    public interface IShopItemsDatabaseService
    {
        ShopItem GetShopItem(int shopItemId);
        IEnumerable<ShopItem> GetShopItemsByCategory(int categoryId, int pageNumber);
        Task Add(ShopItem shopItem);
        Task Add(List<ShopItem> shopItems);
        Task Delete(int shopItemId);
        Task Update(ShopItem shopItem);
    }
}
