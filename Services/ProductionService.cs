using FECompanyDashboard.Models;
using System.Net.Http.Json;

namespace FECompanyDashboard.Services;

public class ProductionService
{
    private readonly AuthorizedHttpClient _authHttp;

    public ProductionService(AuthorizedHttpClient authHttp)
    {
        _authHttp = authHttp;
    }

    public async Task<List<TrendPoint>> GetDailyTrendAsync()
    {
        var http = await _authHttp.GetClientAsync();
        return await http.GetFromJsonAsync<List<TrendPoint>>(
            "/production/trend/daily") ?? new();
    }

    public async Task<List<TrendPoint>> GetMonthlyTrendAsync()
    {
        var http = await _authHttp.GetClientAsync();
        return await http.GetFromJsonAsync<List<TrendPoint>>(
            "/production/trend/monthly") ?? new();
    }

    public async Task<List<CapacityDto>> GetCapacityAsync()
    {
        var http = await _authHttp.GetClientAsync();
        return await http.GetFromJsonAsync<List<CapacityDto>>(
            "/production/capacity") ?? new();
    }

    public async Task<List<YieldDto>> GetYieldAsync()
    {
        var http = await _authHttp.GetClientAsync();
        return await http.GetFromJsonAsync<List<YieldDto>>(
            "/production/yield") ?? new();
    }
}
