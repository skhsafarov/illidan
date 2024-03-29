using Grpc.Core;
using Server.Models;
using Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Server.Services
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
            var user = _db.Users.FirstOrDefault(v => v.Phone == request.Phone);
            if (user != null)
            {
                if (user.Attempts > 0)
                {
                    user.Code = code;
                    user.Expiration = DateTime.UtcNow.AddMinutes(3);
                    user.Attempts -= 1;
                }
                else if (user.Attempts == 0 && (DateTime.UtcNow - user.Expiration).Days > 0)
                {
                    user.Code = code;
                    user.Expiration = DateTime.UtcNow.AddMinutes(3);
                    user.Attempts = 10;
                }
            }
            // If not, create a new record
            else
            {
                User newUser = new User(request.Phone, request.Phone, code);
                _db.Users.Add(newUser);
            }
            _db.SaveChanges();
            // Send the code to the phone number
            Console.WriteLine($"Phone: {request.Phone} Code: {code}");
            return Task.FromResult<StandartReply>(new StandartReply() { Success = true });
        }

        public  override Task<ValidateReply> Validate(ValidateRequest request, ServerCallContext context)
        {
            // Get phone from claims
            var phone = request.Phone;
            // Check if code is valid
            var usr = _db.Users.FirstOrDefault(x => x.Phone == phone);
            if (usr == null)
            {
                return Task.FromResult(new ValidateReply() { Success = false, Message = "Phone not found" });
            }
            else if (usr.Code == null)
            {
                return Task.FromResult(new ValidateReply() { Success = false, Message = "Code is null" });
            }
            else if (usr.Code != request.Code)
            {
                return Task.FromResult(new ValidateReply() { Success = false, Message = "Code is not correct" });
            }
            else
            {
                usr.Attempts = 10;
                _db.SaveChanges();
                return Task.FromResult(new ValidateReply() { Success = true, AccessToken = CreateAccessToken(usr) });
            }
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