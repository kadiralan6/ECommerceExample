using ECommerce.Core.Entities.ConcreteDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Dtos.CategoryDtos
{
    public class CategoryUpdateOrDeleteDto : DtoGetBase
    {
        public int Id { get; set; }
        public string   Name { get; set; }
        public bool Deleted { get; set; }

    }
}
