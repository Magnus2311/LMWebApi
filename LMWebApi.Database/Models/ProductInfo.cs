using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Database.Models
{
    public class ProductInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Carbohydrates Carbohydrates { get; set; } = new Carbohydrates();
        public Vitamins Vitamins { get; set; } = new Vitamins();
        public AminoAcids AminoAcids { get; set; } = new AminoAcids();
        public Fats Fats { get; set; } = new Fats();
        public Minerals Minerals { get; set; } = new Minerals();
        public Sterols Sterols { get; set; } = new Sterols();
        public Others Others { get; set; } = new Others();

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}