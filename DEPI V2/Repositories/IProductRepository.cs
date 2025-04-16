using DEPI_V2.Models;

namespace DEPI_V2.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<Product>> GetProductsInStock();
        Task<Product?> GetProductWithCategory(int id);
    }
} 