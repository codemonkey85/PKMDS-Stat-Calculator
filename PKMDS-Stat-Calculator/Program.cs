using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PKMDS_Stat_Calculator.Shared;
using PokeApiNet;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PKMDS_Stat_Calculator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IRefreshService, RefreshService>();
            builder.Services.AddScoped<IThemeService, ThemeService>();
            builder.Services.AddScoped(sp => new PokeApiClient());

            await builder.Build().RunAsync();
        }
    }
}
