var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

var services = builder.Services;
const string httpClientName = "httpClient";

services
    .AddHttpClient(httpClientName, client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

services
    .AddMudServices()
    .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(httpClientName))
    .AddScoped<PokeApiClient>();

await builder.Build().RunAsync();
