using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMWebApi.Database.Models
{
    public class ShopItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ShopCategoryId { get; set; }
        public ShopCategory ShopCategory { get; set; }
    }
}
