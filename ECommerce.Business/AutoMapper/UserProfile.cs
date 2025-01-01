using AutoMapper;
using ECommerce.Core.Entities.Concrete;
using ECommerce.Entities.Dtos.ProductDtos;
using ECommerce.Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.AutoMapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserForLoginDto, User>();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}
