using DEPI_V2.Data;
using DEPI_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace DEPI_V2.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetCategoryWithProducts(int id)
        {
            return await _dbSet
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithProducts()
        {
            return await _dbSet
                .Include(c => c.Products)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbSet
                .Include(c => c.Products)
                .ToListAsync();
        }
    }
} 