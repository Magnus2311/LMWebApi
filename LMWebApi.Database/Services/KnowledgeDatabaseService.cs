using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMWebApi.Database.Services
{
    public class KnowledgeDatabaseService : IKnowledgeDatabaseService
    {
        public IEnumerable<KnowledgeCategory> GetAllKnowledgeCategories()
        {
            return new LMDbContext().KnowledgeCategories;
        }

        public async Task Add(KnowledgeCategory knowledgeCategory)
        {
            var dbContext = new LMDbContext();
            await dbContext.KnowledgeCategories.AddAsync(knowledgeCategory);
            await dbContext.SaveChangesAsync();
        }

        public async Task Add(List<KnowledgeCategory> knowledgeCategories)
        {
            var dbContext = new LMDbContext();
            await dbContext.KnowledgeCategories.AddRangeAsync(knowledgeCategories);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(string knowledgeCategoryId)
        {
            var dbContext = new LMDbContext();
            var knowledgeCategory = await dbContext.KnowledgeCategories.FirstOrDefaultAsync(c => c.Id == int.Parse(knowledgeCategoryId));
            dbContext.Remove(knowledgeCategory);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(KnowledgeCategory knowledgeCategory)
        {
            var dbContext = new LMDbContext();
            var knowledgeCategoryToUpdate = await dbContext.KnowledgeCategories.FirstOrDefaultAsync(c => c.Id == knowledgeCategory.Id);
            knowledgeCategoryToUpdate = knowledgeCategory;
            await dbContext.SaveChangesAsync();
        }
    }
}
