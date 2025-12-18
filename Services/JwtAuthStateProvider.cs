using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace FECompanyDashboard.Services;

public class JwtAuthStateProvider : AuthenticationStateProvider
{
    private const string TokenKey = "auth_token";
    private readonly IJSRuntime _js;

    public JwtAuthStateProvider(IJSRuntime js)
    {
        _js = js;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _js.InvokeAsync<string>(
            "localStorage.getItem", TokenKey);

        if (string.IsNullOrWhiteSpace(token))
        {
            return new AuthenticationState(
                new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var identity = new ClaimsIdentity(
            new[] { new Claim(ClaimTypes.Name, "User") },
            "jwt");

        return new AuthenticationState(
            new ClaimsPrincipal(identity));
    }

    public async Task SetTokenAsync(string token)
    {
        await _js.InvokeVoidAsync(
            "localStorage.setItem", TokenKey, token);

        NotifyAuthenticationStateChanged(
            GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await _js.InvokeVoidAsync(
            "localStorage.removeItem", TokenKey);

        NotifyAuthenticationStateChanged(
            GetAuthenticationStateAsync());
    }
}
