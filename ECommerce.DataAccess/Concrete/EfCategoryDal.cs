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
    public class EfCategoryDal : EfEntityRepositoryBase<Category,ECommerContext>,ICategoryDal
    {
        public EfCategoryDal(ECommerContext context) : base(context)
        {
        }
    }
}
