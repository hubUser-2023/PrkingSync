using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ParkingSync.Utilities;

public static class HttpClientFactory
{
public static HttpClient CreateClient()
{
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer 11111-aaaaa-55555");
    return client;
}
}
