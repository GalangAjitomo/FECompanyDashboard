using FECompanyDashboard.Models;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace FECompanyDashboard.Services;

public class AuthService
{
    private const string TokenKey = "auth_token";
    private readonly HttpClient _http;
    private readonly IJSRuntime _js;

    public AuthService(HttpClient http, IJSRuntime js)
    {
        _http = http;
        _js = js;
    }

    public async Task<bool> LoginAsync(LoginRequest request)
    {
        var response = await _http.PostAsJsonAsync("/auth/login", request);

        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

        await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, result!.Token);

        _http.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.Token);

        return true;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await _js.InvokeAsync<string>(
            "localStorage.getItem", TokenKey);

        return !string.IsNullOrWhiteSpace(token);
    }

    public async Task LogoutAsync()
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
    }
}
