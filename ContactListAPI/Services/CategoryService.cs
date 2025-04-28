using ContactListAPI.Data;
using ContactListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ContactListDataContext _context;
        public CategoryService(ContactListDataContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
    }
}
