using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeController : ControllerBase
    {
        private readonly IKnowledgeDatabaseService knowledgeDatabaseService;
        private readonly IArticlesDatabaseService articlesDatabaseService; 

        public KnowledgeController(IKnowledgeDatabaseService _knowledgeDatabaseService, IArticlesDatabaseService _articlesDatabaseService)
        {
            knowledgeDatabaseService = _knowledgeDatabaseService;
            articlesDatabaseService = _articlesDatabaseService;
        }

        [HttpGet]
        public IEnumerable<KnowledgeCategory> Get()
        {
            var knowledge = knowledgeDatabaseService.GetAllKnowledgeCategories();
            return knowledge == null ? new List<KnowledgeCategory>() : knowledge;
        }

        [HttpGet("article")]
        public async Task<Article> GetArticle(int articleId)
        {
            var article = await articlesDatabaseService.GetArticle(articleId);
            return article;
        }

        [HttpGet("articles")]
        public IEnumerable<Article> GetArticles(int knowledgeCategoryId, int pageNumber)
        {
            var articles = articlesDatabaseService.GetArticlesByCategory(knowledgeCategoryId, pageNumber);
            return articles == null ? new List<Article>() : articles;
        }

        [HttpPost]
        public async Task<KnowledgeCategory> Post(KnowledgeCategory category)
        {
            if (ModelState.IsValid)
            {
                await knowledgeDatabaseService.Add(category);
                return category;
            }
            throw new Exception();
        }

        [HttpPut]
        public async Task Put(KnowledgeCategory category) => await knowledgeDatabaseService.Update(category);

        [HttpDelete]
        public async Task Delete(string categoryId) => await knowledgeDatabaseService.Delete(categoryId);

        [HttpPost("article")]
        public async Task<Article> PostArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                await articlesDatabaseService.Add(article);
                return article;
            }
            throw new Exception();
        }

    }
}
