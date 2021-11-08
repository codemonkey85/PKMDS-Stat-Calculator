using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PKMDS_Stat_Calculator;
using PKMDS_Stat_Calculator.Shared;
using PokeApiNet;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IRefreshService, RefreshService>();
builder.Services.AddScoped<IThemeService, ThemeService>();
builder.Services.AddScoped(sp => new PokeApiClient());

await builder.Build().RunAsync();
