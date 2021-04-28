using LMWebApi.Common.Models.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMWebApi.Database.Interfaces
{
    public interface IShopDatabaseService
    {
        IEnumerable<ShopCategory> GetAllCategories();
        Task Add(ShopCategory shopCategory);
        Task Add(List<ShopCategory> shopCategories);
        Task Delete(int shopCategoryId);
        Task Update(ShopCategory shopCategory);
    }
}
