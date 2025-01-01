using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Extensions
{
    //extension metotlarda hem sınıf hem metot static olmalı
    public static class ClaimExtensions
    {
        //claim, genellikle JSON Web Token(JWT) içinde kullanıcıya ait bilgilerin veya özelliklerin temsil edildiği bir yapıdır.
        public static void AddEmail(this ICollection<Claim> claims, string email) //this mevzuyu extend ediyoz. Bu kod belirli bir email adresini ekleyen extension kodudur.
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
