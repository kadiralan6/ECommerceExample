using ECommerce.Core.Utilities.Abstract;
using ECommerce.Entities.Dtos.CategoryDtos;
using ECommerce.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryListDto>> GetAllAsync();
        Task<IResult> UpdateOrDeleteAsync(CategoryUpdateOrDeleteDto categoryUpdateOrDeleteDto, bool deleted);
        Task<IResult> AddAsync(CategoryAddDto categoryAddDto);
    }
}
