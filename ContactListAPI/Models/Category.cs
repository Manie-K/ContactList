namespace ContactListAPI.Models
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required bool AllowCustomSubcategory { get; set; } = false;
        public List<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}
