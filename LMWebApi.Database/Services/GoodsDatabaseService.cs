using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMWebApi.Database.Services
{
    public class GoodsDatabaseService : IGoodsDatabaseService
    {
        private readonly LMDbContext dbContext;

        public GoodsDatabaseService(LMDbContext context)
        {
            dbContext = context;
        }

        public void AddGood()
        {
            throw new NotImplementedException();
        }

        public void DeleteGood()
        {
            throw new NotImplementedException();
        }

        public List<Good> GetGoods()
        {
            throw new NotImplementedException();
        }
    }
}
