using ECommerce.Core.Entities.Concrete;


namespace ECommerce.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        //kullanıcı giriş için basacak.
        //doğruysa CreateToken çalıack. Veritabanına gidecek oradaki claimleri bulacak. sonra jwt üretecek. 
    }
}
