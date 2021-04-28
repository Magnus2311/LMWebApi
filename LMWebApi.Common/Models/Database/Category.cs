using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Common.Models.Database
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }

        public string ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> SubCategories { get; set; } = new List<Category>();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}