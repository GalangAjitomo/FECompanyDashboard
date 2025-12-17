using FECompanyDashboard.Models;
using System.Net.Http.Json;

namespace FECompanyDashboard.Services;

public class TrendService
{
    private readonly HttpClient _http;

    public TrendService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TrendPoint>> GetTrendAsync()
    {
        try
        {
            var result = await _http
                .GetFromJsonAsync<List<TrendPoint>>("/production/trend");

            return result ?? GetDummyData();
        }
        catch
        {
            return GetDummyData();
        }
    }

    private List<TrendPoint> GetDummyData()
    {
        return Enumerable.Range(1, 7)
            .Select(i => new TrendPoint
            {
                Date = DateTime.Today.AddDays(-7 + i),
                Value = 100 + i * 10
            })
            .ToList();
    }
}
