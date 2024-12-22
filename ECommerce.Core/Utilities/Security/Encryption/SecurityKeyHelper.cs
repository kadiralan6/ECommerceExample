using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {  //appsettingjson içersindeki securtkeyi burda byte array haline getiriyor. Simetrik anahtara yarıyor.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

        }
    }
}
