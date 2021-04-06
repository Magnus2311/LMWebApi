using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Common.Models.Database
{
    public class Fats
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public decimal FatsVal { get; set; }
        public decimal Monounsaturated { get; set; }
        public decimal PolyunsaturatedFats { get; set; }
        public decimal SaturatedFats { get; set; }
        public decimal TransFats { get; set; }

        public string ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }
    }
}
