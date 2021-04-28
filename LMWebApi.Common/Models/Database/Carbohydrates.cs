using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Common.Models.Database
{
    public class Carbohydrates
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public decimal Fibres { get; set; }
        public decimal Starchs { get; set; }
        public decimal Sugar { get; set; }
        public decimal Galactose { get; set; }
        public decimal Glucose { get; set; }
        public decimal Sucrose { get; set; }
        public decimal Lactose { get; set; }
        public decimal Maltose { get; set; }
        public decimal Fructose { get; set; }

        public string ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }
    }
}
