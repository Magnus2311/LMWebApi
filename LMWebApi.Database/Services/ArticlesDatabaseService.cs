using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMWebApi.Database.Services
{
    public class ArticlesDatabaseService : IArticlesDatabaseService
    {
        public async Task<Article> GetArticle(int articleId)
        {
            return await new LMDbContext().Articles.Include(a=>a.KnowledgeCategory).FirstOrDefaultAsync(a => a.Id == articleId);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return new LMDbContext().Articles;
        }

        public IEnumerable<Article> GetArticlesByCategory(int categoryId,int pageNumber)
        {
            return new LMDbContext().Articles?.Where(a => a.KnowledgeCategoryId == categoryId).Take(pageNumber * 30);
        }

        public async Task Add(Article article)
        {
            var dbContext = new LMDbContext();
            await dbContext.Articles.AddAsync(article);
            await dbContext.SaveChangesAsync();
        }

        public async Task Add(List<Article> articles)
        {
            var dbContext = new LMDbContext();
            await dbContext.Articles.AddRangeAsync(articles);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int articleId)
        {
            var dbContext = new LMDbContext();
            var article = await dbContext.Articles.FirstOrDefaultAsync(c => c.Id == articleId);
            dbContext.Remove(article);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Article article)
        {
            var dbContext = new LMDbContext();
            var articleToUpdate = await dbContext.Articles.FirstOrDefaultAsync(c => c.Id == article.Id);
            articleToUpdate = article;
            await dbContext.SaveChangesAsync();
        }
    }
}