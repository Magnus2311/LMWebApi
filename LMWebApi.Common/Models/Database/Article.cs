using System;
using System.Collections.Generic;
using System.Text;

namespace LMWebApi.Common.Models.Database
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int? KnowledgeCategoryId { get; set; }
        public string Description { get; set; }
        public KnowledgeCategory KnowledgeCategory { get; set; }
    }
}
