using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Common.Models.Database
{
    public class Vitamins
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public decimal VitaminA { get; set; }
        public decimal VitaminB1 { get; set; }
        public decimal Betaine { get; set; }
        public decimal VitaminB2 { get; set; }
        public decimal VitaminB3 { get; set; }
        public decimal VitaminB5 { get; set; }
        public decimal VitaminB6 { get; set; }
        public decimal VitaminB9 { get; set; }
        public decimal VitaminB12 { get; set; }
        public decimal VitaminC { get; set; }
        public decimal VitaminD { get; set; }
        public decimal VitaminE { get; set; }
        public decimal VitaminK1 { get; set; }
        public decimal VitaminK2 { get; set; }
        public decimal VitaminB4 { get; set; }

        public string ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }
    }
}
