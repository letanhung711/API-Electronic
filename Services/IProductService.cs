using API_Electronic.Models;
using API_Electronic.ViewModels;

namespace API_Electronic.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task<int> Create(ProductModel productModel);
        Task Update(int id, ProductModel productModel);
        Task Delete(int id);
    }
}
