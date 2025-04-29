using ContactListAPI.Data;
using ContactListAPI.DTO;
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
        public async Task<List<GetCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.Include(c => c.Subcategories).ToListAsync();
            var dtos = categories.Select(categories => new GetCategoryDTO
            {
                Id = categories.Id,
                Name = categories.Name,
                AllowCustomSubcategory = categories.AllowCustomSubcategory,
                Subcategories = categories.Subcategories.Select(subcategory => subcategory.Name).ToList()
            }).ToList();
            return dtos;
        }
    }
}
