using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductDal Products { get; }
        ICategoryDal Categories { get; }
        Task<int> SaveAsync();
    }
}
