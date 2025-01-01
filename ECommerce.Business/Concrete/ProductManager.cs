using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.BusinessAspects.BusinessAutofac;
using ECommerce.Business.Utilities;
using ECommerce.Core.Utilities.Abstract;
using ECommerce.Core.Utilities.ComplexTypes;
using ECommerce.Core.Utilities.Concrete;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [SecuredOperation("admin")]
        public async Task<IResult> AddAsync(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Product.ProductAdded);
        }

        public async Task<IDataResult<ProductListDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync(null, a => a.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound, null);
        }

        public async Task<IDataResult<ProductDto>> GetAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(a => a.Id == productId, a => a.Category);
            if (product != null)
            {
                return new DataResult<ProductDto>(ResultStatus.Success, new ProductDto
                {
                    Product = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.NotFound, null);

        }

        public async Task<IResult> UpdateAsync(UpdateProductDto productUpdateDto, DateTime editDate)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            product.EditDate=editDate;
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Product.ProductUpdated(productUpdateDto.Code));
        }
    }
}
