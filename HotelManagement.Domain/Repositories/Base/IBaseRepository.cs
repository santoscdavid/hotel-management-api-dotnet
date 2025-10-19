namespace HotelManagement.Domain.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellation);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellation);
        Task AddAsync(T entity, CancellationToken cancellation);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync(CancellationToken cancellation);
    }
}
