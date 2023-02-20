using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
            => _context = context;

        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>()
                             .AsNoTracking()
                             .ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllEntitiesWithSpec(ISpecification<T> spec)
            => await ApplySpecification(spec).ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>()
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
            => await ApplySpecification(spec).FirstOrDefaultAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
            => SpecificationEvaluator<T>.GetQuery(_context.Set<T>()
                                                          .AsQueryable(),
                                                  spec);
    }
}