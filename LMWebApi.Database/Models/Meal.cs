using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace LMWebApi.Database.Models
{
    public class Meal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ProductMeal> ProductMeals { get; set; } = new List<ProductMeal>();
    }
}