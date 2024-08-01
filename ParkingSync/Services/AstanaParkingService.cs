using System;
using System.Net.Http;
using System.Threading.Tasks;
using ParkingSync.Models;
using ParkingSync.Utilities;
using Polly;
using Polly.CircuitBreaker;

namespace ParkingSync.Services;


public class AstanaParkingService : IParkingService<AstanaParking>
{
    private static readonly HttpClient _client = HttpClientFactory.CreateClient();
    private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;

    public AstanaParkingService()
    {
        _circuitBreakerPolicy = Policy
            .Handle<HttpRequestException>()
            .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));
    }

    public async Task<AstanaParking> GetDataAsync()
    {
        return await _circuitBreakerPolicy.ExecuteAsync(async () =>
        {
            var response = await _client.GetAsync("https://asta.kz/api/parkings");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AstanaParking>();
        });
    }
}
