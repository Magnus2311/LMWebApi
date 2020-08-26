using LMWebApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMWebApi.Database.Interfaces
{
    public interface IGoodsDatabaseService
    {
        List<Good> GetGoods();

        void AddGood();

        void DeleteGood();
    }
}

