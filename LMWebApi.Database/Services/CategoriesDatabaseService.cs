using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMWebApi.Database;
using LMWebApi.Database.Models;
using Microsoft.EntityFrameworkCore;

public class CategoriesDatabaseService : ICategoriesDatabaseService
{
    public async Task Add(Category category)
    {
        var dbContext = new LMDbContext();
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
    }

    public async Task Add(List<Category> categories)
    {
        var dbContext = new LMDbContext();
        await dbContext.Categories.AddRangeAsync(categories);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(string categoryId)
    {
        var dbContext = new LMDbContext();
        var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        dbContext.Remove(category);
        await dbContext.SaveChangesAsync();
    }

    public IEnumerable<Category> GetAll() => new LMDbContext().Categories;

    public async Task Update(Category category)
    {
        var dbContext = new LMDbContext();
        var categoryToUpdate = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
        categoryToUpdate = category;
        await dbContext.SaveChangesAsync();
    }
}
