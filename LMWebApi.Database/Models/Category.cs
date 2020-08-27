using System.Collections.Generic;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }

    public int? ParentId { get; set; }
    public Category Parent { get; set; }
    public List<Category> SubCategories { get; set; } = new List<Category>();
}