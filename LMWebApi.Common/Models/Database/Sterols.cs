using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Common.Models.Database
{

    public class Sterols
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public decimal Cholesterol { get; set; }
        public decimal Phytosterols { get; set; }
        public decimal Stigmasterols { get; set; }
        public decimal Campesterols { get; set; }
        public decimal BetaSitosterols { get; set; }

        public string ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }
    }
}