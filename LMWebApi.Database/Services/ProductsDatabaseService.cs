using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMWebApi.Database.Services
{
    public class ProductsDatabaseService : IProductsDatabaseService
    {
        public async Task AddProduct(Product product)
        {
            var dbContext = new LMDbContext();
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var dbContext = new LMDbContext();
            var product = await dbContext.Products.FindAsync(productId);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<Product> GetProducts()
        {
            var dbContext = new LMDbContext();
            return dbContext.Products;
        }

        public async Task UpdateProduct(Product product)
        {
            var dbContext = new LMDbContext();
            var productToUpdate = await dbContext.Products.FindAsync(product.Id);
            productToUpdate = product;
            await dbContext.SaveChangesAsync();
        }
    }
}
