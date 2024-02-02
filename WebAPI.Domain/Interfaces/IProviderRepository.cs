using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces
{
    public interface IProviderRepository : IGenericRepository<Provider>
    {
        Task<IEnumerable<Provider>> GetAllAsync();
        Task<Provider> GetDocumentAsync(long id);
    }
}