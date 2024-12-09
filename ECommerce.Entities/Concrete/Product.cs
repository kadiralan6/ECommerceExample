using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public required string  Name { get; set; }
        public required string  Code { get; set; }
        public  double Price { get; set; }
        public double Quantity { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public DateTime EditDate { get; set; }
    }
}
