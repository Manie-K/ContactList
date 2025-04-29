using ContactListAPI.DTO;
using ContactListAPI.Models;

namespace ContactListAPI.Services
{
    /// <summary>
    /// Service for managing all available categories.
    /// </summary>
    public interface ICategoryService
    {
        public Task<List<GetCategoryDTO>> GetAllCategoriesAsync();
    }
}
