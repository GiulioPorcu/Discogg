using Application.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

namespace Application
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Providers
            builder.Services.AddScoped(httpClientProvider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(mudThemeProvider => new MudThemeProvider());

            // JS Interop
            builder.Services.AddScoped<LocalStorageService>();
            builder.Services.AddScoped<ThemeService>();

            // MudBlazor
            builder.Services.AddMudServices();
            await builder.Build().RunAsync();
        }
    }
}