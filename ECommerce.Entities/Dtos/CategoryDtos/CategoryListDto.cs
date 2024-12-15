using ECommerce.Core.Entities.ConcreteDto;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Dtos.CategoryDtos
{
    public class CategoryListDto :DtoGetBase
    {
       public IList<Category> Categories { get; set; }
    }
}
