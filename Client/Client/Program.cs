using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Blazored.Toast;
using Client.Services;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddBlazoredToast();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<CustomAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            var serverUri = "https://localhost:5001";
            var channelOptions = new GrpcChannelOptions { HttpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()) };
            builder.Services.AddSingleton(new ExchangeService.ExchangeServiceClient(GrpcChannel.ForAddress(serverUri, channelOptions)));
            builder.Services.AddSingleton(new AuthService.AuthServiceClient(GrpcChannel.ForAddress(serverUri, channelOptions)));
            builder.Services.AddSingleton(new QueueService.QueueServiceClient(GrpcChannel.ForAddress(serverUri, channelOptions)));

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://script.google.com/macros/s/") });

            await builder.Build().RunAsync();
        }
    }
}