using API_Electronic.Models;
using API_Electronic.Repositories;
using API_Electronic.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API_Electronic.Services
{
    public class ProductService : IProductService
    {
        private readonly ElectronicDbContext _context;
        private readonly IProductRepository _productRepository;

        public ProductService(ElectronicDbContext context, IProductRepository productRepository) 
        {
            _context = context;
            _productRepository = productRepository;
        }
        public async Task<int> Create(ProductModel productModel)
        {
            if(productModel == null)
            {
                throw new ArgumentNullException("Product model is null.");
            }

            var existingProductByName = await _productRepository.GetByName(productModel.ProductName);
            if (existingProductByName != null)
            {
                throw new ArgumentException("Name already exists");
            }

            var product = new Product
            {
                ProductName = productModel.ProductName,
                Price = productModel.Price,
                quantity = productModel.quantity,
                Note = productModel.Note
            };
            return await _productRepository.Create(product);
        }

        public async Task Delete(int id)
        {
            var product = await _productRepository.GetById(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Product not found.");
            }
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _productRepository.GetById(id);
            return product == null ? throw new ArgumentException("Product not found.") : product;
        }

        public async Task Update(int id, ProductModel productModel)
        {
            if(productModel == null)
            {
                throw new ArgumentNullException("Product model is null.");
            }

            var getProduct = await _productRepository.GetById(id);
            if(getProduct == null)
            {
                throw new ArgumentException("Product not found.");
            }

            getProduct.ProductName = productModel.ProductName;
            getProduct.Price = productModel.Price;
            getProduct.quantity = productModel.quantity;
            getProduct.Note = productModel.Note;
            getProduct.Update_Time = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new ArgumentException("An error occurred while updating product.", ex);
            }
        }
    }
}
