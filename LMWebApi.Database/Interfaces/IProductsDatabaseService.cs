using System.Threading.Tasks;
using System.Collections.Generic;
using LMWebApi.Common.Models.Database;

namespace LMWebApi.Database.Interfaces
{
    public interface IProductsDatabaseService
    {
        IEnumerable<Product> GetProducts();

        Task AddProduct(Product product);

        Task DeleteProduct(string productId);
        Task UpdateProduct(Product product);
    }
}

