using ECommerce.Business.Abstract;
using ECommerce.Entities.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("addCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryAddDto categoryAddDto)
        {
            if (categoryAddDto != null)
            {
                var result = await _categoryService.AddAsync(categoryAddDto);
                return Ok(result.Message);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
