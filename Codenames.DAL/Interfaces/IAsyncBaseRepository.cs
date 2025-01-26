using Codenames.Models;

namespace Codenames.DAL.Interfaces
{
    public interface IAsyncBaseRepository<T> where T : IBaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T model);
        Task<T> UpdateAsync(T model);
        Task DeleteAsync(Guid Id);
    }
}
