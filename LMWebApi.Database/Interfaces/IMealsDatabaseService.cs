using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;

namespace LMWebApi.Database.Interfaces
{
    public interface IMealsDatabaseService
    {
        Task Add(Meal meal);
        Task Delete(string mealId);
        IEnumerable<Meal> GetAll();
        Task Update(Meal meal);
    }
}