using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Database.Models
{
    public class AminoAcids
    {
        public decimal AsparticAcid;
        public decimal Hydroxyproline;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public decimal Alanine { get; set; }
        public decimal Arginine { get; set; }
        public decimal Valin { get; set; }
        public decimal Glycine { get; set; }
        public decimal Glutamine { get; set; }
        public decimal Isoleucine { get; set; }
        public decimal Leucine { get; set; }
        public decimal Lysine { get; set; }
        public decimal Methionine { get; set; }
        public decimal Proline { get; set; }
        public decimal Serine { get; set; }
        public decimal Tyrosine { get; set; }
        public decimal Threonine { get; set; }
        public decimal Tryptophan { get; set; }
        public decimal Phenylalanine { get; set; }
        public decimal Histidine { get; set; }
        public decimal Cystine { get; set; }

        public string ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }
    }
}
