using DEPI_V2.Data;
using DEPI_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace DEPI_V2.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsInStock()
        {
            return await _dbSet.Where(p => p.StockQuantity > 0).ToListAsync();
        }

        public async Task<Product?> GetProductWithCategory(int id)
        {
            return await _dbSet
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
} 