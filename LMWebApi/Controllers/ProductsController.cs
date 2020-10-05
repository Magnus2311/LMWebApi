using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMWebApi.Database.Interfaces;
using System.Collections.Generic;
using LMWebApi.Database.Models;
using System;

namespace LMWebApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsDatabaseService _productsDbService;

        public ProductsController(IProductsDatabaseService productsDbService)
        {
            _productsDbService = productsDbService;
        }

        [HttpGet]
        public IEnumerable<Product> Get() => _productsDbService.GetProducts();

        [HttpPost]
        public async Task<Product> Post(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productsDbService.AddProduct(product);
                return product;
            }

            throw new Exception();
        }

        [HttpPut]
        public async Task Put(Product product)
        {
            await _productsDbService.UpdateProduct(product);
        }

        [HttpDelete]
        public async Task Delete(string productId)
        {
            await _productsDbService.DeleteProduct(productId);
        }
    }
}