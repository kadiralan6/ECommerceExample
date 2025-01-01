using ECommerce.Business.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using ECommerce.Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using ECommerce.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Core.Extensions;

namespace ECommerce.Business.BusinessAspects.BusinessAutofac
{
    //Jwt için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//jwt göndrerek yapılan istek için http context oluşur.

        //roller virgülle ayrılarak geliyor.
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //kullanıcının rollerini gez kullanıcının yetkisi eşleşiyorsa devam et yoksa hata ver
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
