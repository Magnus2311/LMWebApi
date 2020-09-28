using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Database.Models
{
    public class Others
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public decimal Alcohol { get; set; }
        public decimal Water { get; set; }
        public decimal Caffeine { get; set; }
        public decimal Theobromine { get; set; }
        public decimal Cinder { get; set; }

        public string ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }
    }
}