using LMWebApi.Database.Models;
using System.Collections.Generic;

namespace LMWebApi.Database.Interfaces
{
    public interface IGoodsDatabaseService
    {
        IEnumerable<Product> GetGoods();

        void AddGood();

        void DeleteGood();
    }
}

