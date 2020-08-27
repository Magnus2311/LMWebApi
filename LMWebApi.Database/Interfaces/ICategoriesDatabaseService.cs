using System.Threading.Tasks;
using System.Collections.Generic;

public interface ICategoriesDatabaseService
{
    IEnumerable<Category> GetAll();
    Task Add(Category category);
    Task Delete(int categoryId);
    Task Update(Category category);
}