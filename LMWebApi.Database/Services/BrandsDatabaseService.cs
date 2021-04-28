using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using System.Collections.Generic;

namespace LMWebApi.Database.Services
{
    public class BrandsDatabaseService : IBrandsDatabaseService
    {
        public IEnumerable<Brand> GetAll() => new LMDbContext().Brands;
    }
}
