using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Utilities.IoC
{
    //Bu kod, .NET uygulamalarında DI kullanımı ile ilgili bir yardımcı sınıf sunar. Temelde, servislerin kaydedilmesi
    //ve daha sonra bu servislere erişim sağlanması için bir servis sağlayıcı oluşturur.
    //Uygulamanın merkezi bir yerinden servisleri erişilebilir kılmak amacıyla kullanılır.
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
