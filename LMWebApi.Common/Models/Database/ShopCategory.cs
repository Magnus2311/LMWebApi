using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMWebApi.Common.Models.Database
{
    public class ShopCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int? ParentId { get; set; }
        public ShopCategory Parent { get; set; }
        public List<ShopCategory> SubCategories { get; set; } = new List<ShopCategory>();
        public List<ShopItem> ShopItems { get; set; } = new List<ShopItem>();
    }
}
