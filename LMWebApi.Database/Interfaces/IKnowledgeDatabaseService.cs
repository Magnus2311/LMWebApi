using LMWebApi.Common.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMWebApi.Database.Interfaces
{
    public interface IKnowledgeDatabaseService
    {
        IEnumerable<KnowledgeCategory> GetAllKnowledgeCategories();
        Task Add(KnowledgeCategory knowledgeCategory);
        Task Add(List<KnowledgeCategory> knowledgeCategories);
        Task Delete(string knowledgeCategoryId);
        Task Update(KnowledgeCategory knowledgeCategory);
    }
}
