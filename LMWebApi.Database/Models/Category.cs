using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LMWebApi.Database.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Image { get; set; }

    public int? ParentId { get; set; }
    public Category Parent { get; set; }
    public List<Category> SubCategories { get; set; } = new List<Category>();
    public List<Product> Products { get; set; } = new List<Product>();
}