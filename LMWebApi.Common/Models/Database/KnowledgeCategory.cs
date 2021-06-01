using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMWebApi.Common.Models.Database
{
    public class KnowledgeCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int? ParentId { get; set; }
        public KnowledgeCategory Parent { get; set; }
        public List<KnowledgeCategory> SubCategories { get; set; } = new List<KnowledgeCategory>();
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
