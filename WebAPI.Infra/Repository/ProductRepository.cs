using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Database;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Repository;

namespace Pr.Web.Infra.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _Context;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _Context = dbContext;
        }

        public async Task<Product> GetByProductAsync(int ProductId)
        {
            return await _Context.Product.
                   Include(x => x.Provider).
                   FirstOrDefaultAsync(x => x.Id == ProductId);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string Status, long document, int ProviderId)
        {
            var list = await _Context.Product.Include(x => x.Provider).OrderBy(on => on.Id).ToListAsync();

            if (Status != "")
            {
                list = list.Where(x => x.Status == Status).ToList();
            }
            if (document > 0)
            {
                list = list.Where(x => x.Provider!.Document == document).ToList();
            }

            if (ProviderId > 0)
            {
                list = list.Where(x => x.Provider!.Id == ProviderId).ToList();
            }

            return list;
        }
    }
}
