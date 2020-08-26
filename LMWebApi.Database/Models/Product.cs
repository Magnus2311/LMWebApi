using System.ComponentModel.DataAnnotations;

namespace LMWebApi.Database.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public decimal Carbohydrates { get; set; }

        public decimal Fats { get; set; }

        public decimal Calories { get; set; }

        public decimal Protein { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
