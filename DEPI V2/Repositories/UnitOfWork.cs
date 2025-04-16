using DEPI_V2.Data;

namespace DEPI_V2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IProductRepository? _products;
        private ICategoryRepository? _categories;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _products ??= new ProductRepository(_context);
        public ICategoryRepository Categories => _categories ??= new CategoryRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
} 