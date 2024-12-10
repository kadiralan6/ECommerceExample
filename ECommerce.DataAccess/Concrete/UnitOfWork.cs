using ECommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerContext _context;
        private EfCategoryDal _categoryDal;
        private EfProductDal _productDal;

        public UnitOfWork(ECommerContext context)
        {
            _context = context;
        }
        public IProductDal Products => _productDal ?? new EfProductDal(_context);

        public ICategoryDal Categories => _categoryDal ?? new EfCategoryDal(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
