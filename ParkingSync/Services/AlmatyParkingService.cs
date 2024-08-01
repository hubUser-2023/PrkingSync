using ParkingSync.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.CircuitBreaker;
using ParkingSync.Utilities;

namespace ParkingSync.Services;
public class AlmatyParkingService : IParkingService<AlmatyParking>
{
    private static readonly HttpClient _client = HttpClientFactory.CreateClient();
    private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;

    public AlmatyParkingService()
    {
        _circuitBreakerPolicy = Policy
            .Handle<HttpRequestException>()
            .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));
    }

    public async Task<AlmatyParking> GetDataAsync()
    {
        return await _circuitBreakerPolicy.ExecuteAsync(async () =>
        {
            var response = await _client.GetAsync("https://alma.kz/api/parkings");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AlmatyParking>();
        });
    }
}
