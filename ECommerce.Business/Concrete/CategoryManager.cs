using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.Utilities;
using ECommerce.Core.Utilities.Abstract;
using ECommerce.Core.Utilities.ComplexTypes;
using ECommerce.Core.Utilities.Concrete;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
        }
        public async Task<IResult> AddAsync(CategoryAddDto categoryAddDto)
        {
            var anyCategories = await _unitOfWork.Categories.GetAllAsync(a => a.Name == categoryAddDto.Name);
            var categoryAdd = _mapper.Map<Category>(categoryAddDto);
            await _unitOfWork.Categories.AddAsync(categoryAdd);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Category.CategoryAdd);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var categoris=  await _unitOfWork.Categories.GetAllAsync();
            if (categoris != null)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categoris,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Warning,Messages.Category.NotFound ,null);
        }

        public async Task<IDataResult<CategoryDto>> GetAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetAsync(a=>a.Id==id);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto { 
                category=category,
                ResultStatus=ResultStatus.Success,
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Warning, Messages.Category.NotFound, null);
        }

        public async Task<IResult> UpdateOrDeleteAsync(CategoryUpdateOrDeleteDto categoryUpdateOrDeleteDto,bool deleted)
        {
            if (deleted)
            {
                var result = await _unitOfWork.Categories.GetAsync(a => a.Id == categoryUpdateOrDeleteDto.Id);
                if (result!=null)
                {
                    result.Deleted = true;
                   await _unitOfWork.Categories.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, Messages.Category.CategoryDeleted);
                }
                return new Result(ResultStatus.Info, Messages.Category.NotFound);
            }
            else
            {
                var category = _mapper.Map<Category>(categoryUpdateOrDeleteDto);
                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Category.CategoryUpdate);

            }
        }
    }
}
