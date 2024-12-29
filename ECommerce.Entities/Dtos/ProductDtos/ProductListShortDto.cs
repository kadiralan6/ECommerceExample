using ECommerce.Entities.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Dtos.ProductDtos
{
    public class ProductListShortDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public CategoryShortDto Category { get; set; }
    }
    public class CategoryShortDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubCategory1 { get; set; }
    }
}
