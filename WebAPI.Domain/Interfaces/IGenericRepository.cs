namespace WebAPI.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task ToDeleteAsync(T entidade);

        Task ToDeleteAllAsync(IEnumerable<T> entidades);

        Task<T> ToSaveAsync(T entidade);

        Task<T> ToUpdateAsync(T entidade);

        Task<T> GetByIdAsync(int id);
    }
}
