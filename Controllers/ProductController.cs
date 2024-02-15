using API_Electronic.Services;
using API_Electronic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Electronic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                return Ok(await _productService.GetAllProduct());
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                return Ok(await _productService.GetProductById(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductModel productModel)
        {
            try
            {
                var productId = await _productService.Create(productModel);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(new { ProductId = productId });
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id) 
        {
            try
            {
                await _productService.Delete(id);
                return Ok(new { Message = "Product deleted successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductModel productModel)
        {
            try
            {
                await _productService.Update(id, productModel);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(new { Message = "Product update successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
