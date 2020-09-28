namespace LMWebApi.Database.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public ProductInfo ProductInfo { get; set; } = new ProductInfo();

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
