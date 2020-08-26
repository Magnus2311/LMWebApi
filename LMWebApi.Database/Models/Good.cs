using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LMWebApi.Database.Models
{
    public class Good
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
