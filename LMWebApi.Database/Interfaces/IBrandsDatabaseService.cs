using LMWebApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMWebApi.Database.Interfaces
{
    public interface IBrandsDatabaseService
    {
        IEnumerable<Brand> GetAll();
    }
}
