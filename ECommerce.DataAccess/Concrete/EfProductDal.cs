using ECommerce.Core.DataAccess.EntityFramework;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ECommerContext>,IProductDal
    {
        public EfProductDal(ECommerContext context) : base(context)
        {
        }
    }
}
