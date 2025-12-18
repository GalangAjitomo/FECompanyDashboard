using FECompanyDashboard;
using FECompanyDashboard.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// =====================
// CONFIG
// =====================
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

if (string.IsNullOrWhiteSpace(apiBaseUrl))
{
    throw new Exception("ApiBaseUrl is not configured in appsettings.json");
}

// =====================
// HTTP CLIENT
// =====================
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(apiBaseUrl)
    });

// =====================
// SERVICES
// =====================
builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();

// 🔥 INI YANG KURANG
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthorizedHttpClient>();
builder.Services.AddScoped<ProductionService>();

await builder.Build().RunAsync();
