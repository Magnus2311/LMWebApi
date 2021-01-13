using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMWebApi.Database.Services
{
    public class BrandsDatabaseService : IBrandsDatabaseService
    {
        public IEnumerable<Brand> GetAll() => new LMDbContext().Brands;
    }
}
