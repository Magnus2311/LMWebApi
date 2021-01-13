using System;
using System.Collections.Generic;
using System.Text;

namespace LMWebApi.Database.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ShopItem> ShopItems { get; set; } = new List<ShopItem>();
    }
}
