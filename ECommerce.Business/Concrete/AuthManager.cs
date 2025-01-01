using ECommerce.Business.Abstract;
using ECommerce.Business.Utilities;
using ECommerce.Core.Entities.Concrete;
using ECommerce.Core.Utilities.Abstract;
using ECommerce.Core.Utilities.ComplexTypes;
using ECommerce.Core.Utilities.Concrete;
using ECommerce.Core.Utilities.Security.Hashing;
using ECommerce.Core.Utilities.Security.JWT;
using ECommerce.Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new DataResult<User>(ResultStatus.Success,Messages.UserRegistered, user);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new DataResult<User>(ResultStatus.Error, Messages.UserNotFound,null);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new DataResult<User>(ResultStatus.Error,Messages.PasswordError, null);
            }

            return new DataResult<User>(ResultStatus.Success, Messages.SuccessfulLogin, userToCheck);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new Result(ResultStatus.Error, Messages.UserAlreadyExists);
            }
            return new Result(ResultStatus.Success);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new DataResult<AccessToken>(ResultStatus.Success, Messages.AccessTokenCreated, accessToken);
        }
    }
}
