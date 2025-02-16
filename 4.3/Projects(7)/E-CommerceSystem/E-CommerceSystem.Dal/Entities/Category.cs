namespace E_CommerceSystem.Dal.Entities;

public class Category
{
    public long CategoryId { get; set; }
    public string Name { get; set; }

    public long ParentCategoryId { get; set; }
    public Category ParentCategory { get; set; }

    public ICollection<Product> Products { get; set; }
}
