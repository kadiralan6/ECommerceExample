using AutoMapper;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>()
                             .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(_ => DateTime.Now))
                             .ForMember(dest => dest.EditDate, opt => opt.MapFrom(_ => DateTime.Now))
                             .ForMember(dest => dest.Deleted, opt => opt.MapFrom(_ => false));
        }

    }
}
