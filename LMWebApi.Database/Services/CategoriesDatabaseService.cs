using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Database;

public class CategoriesDatabaseService : ICategoriesDatabaseService
{
    public async Task Add(Category category)
    {
        var dbContext = new LMDbContext();
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(int categoryId)
    {
        var dbContext = new LMDbContext();
        var category = await dbContext.Categories.FindAsync(categoryId);
        dbContext.Remove(category);
    }

    public IEnumerable<Category> GetAll() => new LMDbContext().Categories;

    public async Task Update(Category category)
    {
        var dbContext = new LMDbContext();
        var categoryToUpdate = await dbContext.Categories.FindAsync(category.Id);
        categoryToUpdate = category;
        await dbContext.SaveChangesAsync();
    }
}
