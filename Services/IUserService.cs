using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using fixit.Entities;
using fixit.Helpers;

namespace fixit.Servicee
{
    public interface IUserService
    {
        UserEntity Authenticate(string username, string password);
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(int id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<UserEntity> _users = new List<UserEntity>
        {
            new UserEntity { UserId = 1, FullName = "Admin", Email = "admin", Password = "admin", Role = RoleEntity.Admin },
             new UserEntity { UserId = 2, FullName = "Normal", Email = "User", Password = "user", Role = RoleEntity.User },


        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserEntity Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Email == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _users;
        }

        public UserEntity GetById(int id)
        {
            var user = _users.FirstOrDefault(x => x.UserId == id);
            return user;
        }
    }
}