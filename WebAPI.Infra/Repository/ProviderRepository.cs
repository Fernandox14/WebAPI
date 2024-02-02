using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Database;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Repository;

namespace Pr.Web.Infra.Repository
{
    public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        private ApplicationDbContext _Context;

        public ProviderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _Context = dbContext;
        }

        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            return await _Context.Provider.ToListAsync();
        }

        public async Task<Provider> GetDocumentAsync(long id)
        {
            return await _Context.Provider.FirstOrDefaultAsync(p=> p.Document == id);
        }
    }
}
