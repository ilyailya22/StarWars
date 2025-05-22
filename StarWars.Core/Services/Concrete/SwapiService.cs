using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWars.Core.Const;
using StarWars.Core.Models;
using StarWars.Core.Services.Abstract;

namespace StarWars.Core.Services.Concrete;

public sealed class SwapiService : ISwapiService
{
    private readonly HttpClient _httpClient = new();

    public async Task<SwapiPersonModel[]> GetStarWarsPeopleAsync()
    {
        var swapiResponse = await GetSwapiEndpointsAsync();
        if (swapiResponse == null)
        {
            return null;
        }
        var rawResponse = await GetApiResponse(swapiResponse.People);
        return JsonConvert.DeserializeObject<SwapiPersonModel[]>(rawResponse);
    }
    
    private async Task<SwapiResponse> GetSwapiEndpointsAsync()
    {
        var rawResponse = await GetApiResponse(Constants.SwapiInfoUrl);
        return JsonConvert.DeserializeObject<SwapiResponse>(rawResponse);
    }
    
    private async Task<string> GetApiResponse(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}