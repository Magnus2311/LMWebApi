using LMWebApi.Common.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMWebApi.Database.Interfaces
{
    public interface IArticlesDatabaseService
    {
        IEnumerable<Article> GetAllArticles();
        IEnumerable<Article> GetArticlesByCategory(int categoryId, int pageNumber);
        Task Add(Article article);
        Task Add(List<Article> articles);
        Task Delete(int articleId);
        Task Update(Article article);
    }
}
