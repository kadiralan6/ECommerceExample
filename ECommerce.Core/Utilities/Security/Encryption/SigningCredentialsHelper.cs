using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {//güvenlik anahtarın bu güvenlik sistemin bu tarzında bir yapıdır bu.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);//
        }
    }
}
