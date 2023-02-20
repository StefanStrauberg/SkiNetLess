using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllEntitiesWithSpec(ISpecification<T> spec);
    }
}