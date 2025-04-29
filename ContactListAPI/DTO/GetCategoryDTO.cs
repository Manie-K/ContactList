using ContactListAPI.Controllers;

namespace ContactListAPI.DTO
{
    /// <summary>
    /// DTO used in the GET request to <see cref="CategoriesController"/> to get basic info about given category.
    /// </summary>
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required bool AllowCustomSubcategory { get; set; } = false;
        public List<string> Subcategories { get; set; } = new List<string>();
    }
}
