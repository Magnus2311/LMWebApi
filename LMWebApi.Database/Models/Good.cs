using System;

namespace LMWebApi.Database.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Carbohydrates { get; set; }

        public decimal Fats { get; set; }

        public decimal Calories { get; set; }

        public decimal Protein { get; set; }

        public Byte[] Image { get; set; }
    }
}
