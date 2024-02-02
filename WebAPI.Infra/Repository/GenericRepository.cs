
using WebAPI.Domain.Database;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Infra.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _session;

        public GenericRepository(ApplicationDbContext session)
        {
            this._session = session;
        }

        public async Task ToDeleteAsync(T entidade)
        {
            _session.Remove(entidade);

            await _session.SaveChangesAsync();
        }

        public async Task ToDeleteAllAsync(IEnumerable<T> entidades)
        {
            _session.RemoveRange(entidades);

            await _session.SaveChangesAsync();
        }

        public async Task<T> ToSaveAsync(T entidade)
        {
            await _session.AddAsync<T>(entidade);
            await _session.SaveChangesAsync();

            return entidade;
        }

        public async Task<T> ToUpdateAsync(T entidade)
        {
            _session.Update(entidade);

            await _session.SaveChangesAsync();

            return entidade;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _session.FindAsync<T>(id);
        }
    }
}
