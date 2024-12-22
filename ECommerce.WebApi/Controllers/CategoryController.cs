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
        [HttpGet("admin/getCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("admin/getCategoriesById/{id}")]
        public async Task<IActionResult> GetCategoriesById([FromQuery] int id)
        {
            var result = await _categoryService.GetAsync(id);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }
        [HttpPost("admin/addCategory")]
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
        [HttpPost("admin/updateOrDeleteCategory")]
        public async Task<IActionResult> UpdateOrDeleteCategory([FromBody] CategoryUpdateOrDeleteDto category,int type)
        {
            if (category != null)
            {
                if (type == 1)
                {
                    var result = await _categoryService.UpdateOrDeleteAsync(category, true);
                    return Ok(result.Message);
                }
                else
                {
                    var result = await _categoryService.UpdateOrDeleteAsync(category, false);
                    return Ok(result.Message);
                }

            }
            else
            {
                return BadRequest();
            }

        }

    }
}
