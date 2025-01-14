﻿using ECommerce.Core.Entities.ConcreteDto;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Dtos.ProductDtos
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
