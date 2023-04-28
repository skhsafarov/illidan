using illidan_Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace illidan_Server
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddGrpc();
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddCors();
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOptions.ISSUER,
                            ValidateAudience = true,
                            ValidAudience = AuthOptions.AUDIENCE,
                            ValidateLifetime = true,
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });

            var app = builder.Build();

            app.UseExceptionHandler("/Error");
            app.UseHsts();
            //app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();
            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<AuthServiceImplementation>().EnableGrpcWeb()
                    .RequireCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
                endpoints.MapGrpcService<QueueServiceImplementation>().EnableGrpcWeb()
                    .RequireCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            app.MapFallbackToFile("index.html");
            app.Run();
        }
        public class AuthOptions
        {
            public const string ISSUER = "MyAuthServer"; // �������� ������
            public const string AUDIENCE = "MyAuthClient"; // ����������� ������
            const string KEY = "mysupersecret_secretkey!123";   // ���� ��� ��������
            public const int LIFETIME = 1; // ����� ����� ������ - 1 ������
            public static SymmetricSecurityKey GetSymmetricSecurityKey()
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            }
        }
    }
}