using System.Threading.Tasks;
using System.Collections.Generic;
using LMWebApi.Database.Models;

public interface ICategoriesDatabaseService
{
    IEnumerable<Category> GetAll();
    Task Add(Category category);
    Task Add(List<Category> categories);
    Task Delete(string categoryId);
    Task Update(Category category);
}