using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Database.Models
{
    public class Minerals
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public decimal Iron { get; set; }
        public decimal Potassium { get; set; }
        public decimal Calcium { get; set; }
        public decimal Magnesium { get; set; }
        public decimal Manganese { get; set; }
        public decimal Copper { get; set; }
        public decimal Sodium { get; set; }
        public decimal Selenium { get; set; }
        public decimal Fluoride { get; set; }
        public decimal Phosphorus { get; set; }
        public decimal Zinc { get; set; }

        public string ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }
    }
}
