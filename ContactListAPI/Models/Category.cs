namespace ContactListAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool AllowCustomSubcategory { get; set; } = false;
        public List<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}
