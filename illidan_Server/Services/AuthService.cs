using Grpc.Core;
using illidan_Server.Models;
using illidan_Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace illidan_Server.Services
{
    public class AuthServiceImplementation : AuthService.AuthServiceBase
    {
        private readonly DataContext _db;
        public AuthServiceImplementation(DataContext db)
        {
            this._db = db;
        }

        public override Task<StandartReply> SendCode(SendCodeRequest request, ServerCallContext context)
        {
            // Generate a random code
            var code = new Random().Next(100000, 999999).ToString();
            // Check if the phone number is already in the database and if so, update the code
            var signin = _db.Users.FirstOrDefault(v => v.Phone == request.Phone);
            if (signin != null)
            {
                if (signin.Attempts > 0)
                {
                    signin.Code = code;
                    signin.Expiration = DateTime.UtcNow.AddMinutes(3);
                    signin.Attempts -= 1;
                }
                else if (signin.Attempts == 0 && (DateTime.UtcNow - signin.Expiration).Days > 0)
                {
                    signin.Code = code;
                    signin.Expiration = DateTime.UtcNow.AddMinutes(3);
                    signin.Attempts = 10;
                }
            }
            // If not, create a new record
            else
            {
                User user = new User(request.Phone);
                _db.Users.Add(user);
            }
            _db.SaveChanges();
            // Send the code to the phone number
            Console.WriteLine("Code: " + code);
            return Task.FromResult<StandartReply>(new StandartReply() { });
        }

        public override Task<ValidateReply> Validate(ValidateRequest request, ServerCallContext context)
        {
            // Get phone from claims
            var phone = request.Phone;
            // Check if code is valid
            var usr = _db.Users.FirstOrDefault(x => x.Phone == phone);
            if (usr!=null && usr.Code == request.Code)
            {
                usr.Attempts = 10;
                _db.SaveChanges();
                return Task.FromResult(new ValidateReply() { AccessToken = CreateAccessToken(usr) });
            }
            return base.Validate(request, context);
        }

        private string CreateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName ?? ""),
                new Claim("Role", user.Role),
                new Claim("Phone", user.Phone),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("super secret key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}