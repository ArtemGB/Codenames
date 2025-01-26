using Codenames.Models;

namespace Codenames.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        T GetById(int id);
        IReadOnlyList<T> GetAll();
        T Add(T model);
        T Update(T model);
        void Delete(Guid Id);

    }
}
