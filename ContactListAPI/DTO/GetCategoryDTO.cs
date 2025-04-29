namespace ContactListAPI.DTO
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AllowCustomSubcategory { get; set; } = false;
        public List<string> Subcategories { get; set; } = new List<string>();
    }
}
