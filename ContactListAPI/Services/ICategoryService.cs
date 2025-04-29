using ContactListAPI.DTO;
using ContactListAPI.Models;

namespace ContactListAPI.Services
{
    public interface ICategoryService
    {
        public Task<List<GetCategoryDTO>> GetAllCategoriesAsync();
    }
}
