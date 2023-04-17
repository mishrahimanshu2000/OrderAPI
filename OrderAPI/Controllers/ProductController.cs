using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Data.Interfaces;
using Order.Model;
using Order.Services.DTOs;
using Order.Services.Interface;

namespace OrderAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _productService.GetProductById(id);
            if(product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("Enter Valid Details");
            }
            await _productService.Add(product);
            return Ok("Product Added successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO product)
        {
            bool res = await _productService.Update(id, product);
            if (!res)
            {
                return NotFound("Product Not found");
            }
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            bool res = await _productService.Delete(id);
            if(!res)
            {
                return NotFound("Product Not found");
            }
            return Ok("product Deleted Successfully");
        }
    }
}
