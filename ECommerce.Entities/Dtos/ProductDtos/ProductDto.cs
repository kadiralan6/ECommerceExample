using ECommerce.Core.Entities;
using ECommerce.Core.Entities.ConcreteDto;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Dtos.ProductDtos
{
    public class ProductDto:DtoGetBase
    {
        public Product Product { get; set; }
    }
}
