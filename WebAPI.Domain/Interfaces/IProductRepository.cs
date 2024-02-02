using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetByProductAsync(int personId);
        Task<IEnumerable<Product>> GetAllAsync(string Status, long document, int ProviderId);
    }
}
