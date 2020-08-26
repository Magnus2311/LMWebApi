using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            var dbContext = new LMDbContext();
            return dbContext.Products;
        }

        public async Task UpdateProduct(Product product)
        {
            var dbContext = new LMDbContext();
            var productToUpdate = dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            productToUpdate = product;
            await dbContext.SaveChangesAsync();
        }
    }
}
