using API_Electronic.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Electronic.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElectronicDbContext _context;
        public ProductRepository(ElectronicDbContext context) 
        {
            _context = context;
        }

        public async Task<int> Create(Product product)
        {
            _context.Set<Product>().Add(product);
            await _context.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Set<Product>().FindAsync(id);
        }

        public async Task<Product?> GetByName(string name)
        {
            return await _context.Set<Product>().FirstOrDefaultAsync(p => p.ProductName == name);
        }
    }
}
