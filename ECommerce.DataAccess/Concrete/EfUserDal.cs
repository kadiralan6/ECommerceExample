using ECommerce.Core.DataAccess.EntityFramework;
using ECommerce.Core.Entities.Concrete;
using ECommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, ECommerContext>, IUserDal
    {
        public EfUserDal(ECommerContext context) : base(context)
        {
        }
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ECommerContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
