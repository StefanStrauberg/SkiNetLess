using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
            => _context = context;

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
            => await _context.ProductBrands
                             .AsNoTracking()
                             .ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id)
            => await _context.Products
                             .AsNoTracking()
                             .Include(x => x.ProductType)
                             .Include(x => x.ProductBrand)
                             .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
            => await _context.Products
                             .AsNoTracking()
                             .Include(x => x.ProductType)
                             .Include(x => x.ProductBrand)
                             .ToListAsync();

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
            => await _context.ProductTypes
                             .AsNoTracking()
                             .ToListAsync();
    }
}