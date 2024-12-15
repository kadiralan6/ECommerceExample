using ECommerce.Core.Entities.ConcreteDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Dtos.CategoryDtos
{
    public class CategoryAddDto : DtoGetBase
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
