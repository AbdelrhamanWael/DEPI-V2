using DEPI_V2.Models;

namespace DEPI_V2.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> GetCategoryWithProducts(int id);
        Task<IEnumerable<Category>> GetCategoriesWithProducts();
    }
} 