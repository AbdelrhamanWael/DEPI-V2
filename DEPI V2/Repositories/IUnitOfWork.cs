namespace DEPI_V2.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        Task<int> SaveChangesAsync();
    }
} 