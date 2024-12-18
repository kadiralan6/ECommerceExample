using AutoMapper;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.CategoryDtos;
using ECommerce.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.AutoMapper
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>()
                            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(_ => DateTime.Now))
                            .ForMember(dest => dest.Deleted, opt => opt.MapFrom(_ => false));
        }
    }
}
