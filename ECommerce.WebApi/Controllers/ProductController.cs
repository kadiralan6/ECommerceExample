using ECommerce.Business.Abstract;
using ECommerce.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("/products/{productId}")]
        public IActionResult GetProductDetails([FromRoute] int productId)
        {
            return Ok();
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddDto productAddDto)
        {
            if (productAddDto == null)
                return BadRequest();
            else
            {
                var result = _productService.AddAsync(productAddDto);
                return Ok(result);
            }
              
        }
    }

}
