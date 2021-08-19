using Contracts;
using Entities;
using Entities.Helper;
using Entities.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUsersRepository
    {
        private SchoolContext _db;
        private readonly AppSettings _appSettings;
        public UserRepository(SchoolContext schoolContext, AppSettings appSettings) : base(schoolContext)
        {
            _db = schoolContext;
            _appSettings = appSettings;

        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = (from x in _db.Users
                        where x.Username == model.Username && x.Password == model.Password
                        select x).FirstOrDefault();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            var user = (from x in _db.Users
                        where x.Id == id
                        select x).FirstOrDefault();
            return user;
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
