var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IRefreshService, RefreshService>();
builder.Services.AddScoped<IThemeService, ThemeService>();
builder.Services.AddScoped(_ => new PokeApiClient());

await builder.Build().RunAsync();
