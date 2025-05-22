using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StarWars.Core.Services.Concrete;

public abstract class ApiServiceBase
{
    private readonly HttpClient _httpClient = new();
    protected async Task<T> GetAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(json);
    }
}