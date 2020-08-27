using System.Threading.Tasks;
using LMWebApi.Database.Models;
using System.Collections.Generic;

namespace LMWebApi.Database.Interfaces
{
    public interface IProductsDatabaseService
    {
        IEnumerable<Product> GetProducts();

        Task AddProduct(Product product);

        void DeleteProduct();
        Task UpdateProduct(Product product);
    }
}

