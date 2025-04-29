namespace ContactListAPI.Models
{
    /// <summary>
    /// Represents a subcategory with a parent category.
    /// </summary>
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
