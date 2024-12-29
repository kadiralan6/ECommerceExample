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
                var result = await _productService.AddAsync(productAddDto);
                return Ok(result.Message);
            }

        }
        [HttpGet("getListProduct")]
        public async Task<IActionResult> GetListProduct()
        {
           var  result= await _productService.GetAllAsync();
            var cleanedData = result.Data.Products.Select(p => new
            {
                p.Id,
                p.Name,
                p.Code,
                p.Price,
                p.Quantity,
                p.IsActive,
                Category = new
                {
                    p.Category.Id,
                    p.Category.Name,
                    p.Category.SubCategory1
                }
            }).ToList();

            return Ok(cleanedData);
        }
    }

}
