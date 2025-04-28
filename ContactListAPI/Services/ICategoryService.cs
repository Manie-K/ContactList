using ContactListAPI.Models;

namespace ContactListAPI.Services
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllCategoriesAsync();
    }
}
