namespace LMWebApi.Database.Models
{
    public class ProductMeal
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string MealId { get; set; }
        public Meal Meal { get; set; }
    }
}