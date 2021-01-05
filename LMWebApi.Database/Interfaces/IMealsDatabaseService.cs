using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Database.Models;

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