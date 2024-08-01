using ParkingSync.Models;
using ParkingSync.Utilities;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ParkingSync.Services;


public class DictionariesService: IDictionariesService
{
    private static readonly HttpClient _client = HttpClientFactory.CreateClient();

    public async Task SendDataAsync(GeoModelsResult data)
    {
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("https://diction.kz/api/compare", content);
        response.EnsureSuccessStatusCode();
    }
}
