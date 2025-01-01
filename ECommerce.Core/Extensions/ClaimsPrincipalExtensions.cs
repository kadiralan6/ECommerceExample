using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Extensions
{
    //ClaimsPrincipal sınıfı, genellikle bir kullanıcının kimlik doğrulama bilgilerini (claim'ler) temsil eden bir sınıftır.
    //Bu kod parçası, ClaimsPrincipal sınıfına, kullanıcının claim verilerine (özellikle rolleri) erişmeyi kolaylaştıran iki yardımcı metod ekler.
    public static class ClaimsPrincipalExtensions
    {
        // Bu metot, belirli bir claim türüne(örneğin roller) sahip olan claim'lerin tüm değerlerini bir liste olarak döndüren bir yardımcı fonksiyondur.
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
