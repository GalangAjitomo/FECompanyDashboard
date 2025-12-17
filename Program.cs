using FECompanyDashboard;
using FECompanyDashboard.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// SAFE read config
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

if (string.IsNullOrWhiteSpace(apiBaseUrl))
{
    throw new Exception("ApiBaseUrl is not configured in appsettings.json");
}

builder.Services.AddScoped(sp =>
{
    return new HttpClient
    {
        BaseAddress = new Uri(apiBaseUrl)
    };
});

builder.Services.AddMudServices();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TrendService>();

await builder.Build().RunAsync();
Console.WriteLine("API BASE URL: " + apiBaseUrl);
