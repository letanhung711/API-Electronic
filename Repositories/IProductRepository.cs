using API_Electronic.Models;

namespace API_Electronic.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetById(int id);
        Task<Product?> GetByName(string name);
        Task<int> Create(Product product);
    }
}
