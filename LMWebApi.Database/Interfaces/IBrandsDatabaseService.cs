using LMWebApi.Common.Models.Database;
using System.Collections.Generic;

namespace LMWebApi.Database.Interfaces
{
    public interface IBrandsDatabaseService
    {
        IEnumerable<Brand> GetAll();
    }
}
