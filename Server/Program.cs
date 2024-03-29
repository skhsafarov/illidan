using Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;

namespace Server
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddGrpc();
            builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
            builder.Services.AddAuthorization();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();


            app.UseExceptionHandler("/Error");
            app.UseHsts();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<AuthServiceImplementation>().RequireCors("AllowAll");
                endpoints.MapGrpcService<QueueServiceImplementation>().RequireCors("AllowAll");
                endpoints.MapGrpcService<ExchangeServiceImplementation>().RequireCors("AllowAll");
            });

            app.MapFallbackToFile("index.html");
            app.Run();
        }




        public class AuthOptions
        {
            public const string ISSUER = "MyAuthServer"; // издатель токена
            public const string AUDIENCE = "MyAuthClient"; // потребитель токена
            const string KEY = "super secret key";   // ключ для шифрации
            public const int LIFETIME = 1; // время жизни токена - 1 минута
            public static SymmetricSecurityKey GetSymmetricSecurityKey()
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            }
        }
    }
}