using System;
using System.Threading.Tasks;
using StarWars.Core.Const;
using StarWars.Core.Models;
using StarWars.Core.Services.Abstract;

namespace StarWars.Core.Services.Concrete;

public sealed class SwapiService: ApiServiceBase, ISwapiService
{
    public Task<CharacterModel[]> GetStarWarsCharactersAsync()
    {
        return Task.FromResult(new CharacterModel[]
        {
            new CharacterModel
            {
                Name = "CharacterModel1"
            },
            new CharacterModel
            {
                Name = "CharacterModel2"
            }
        });
    }

    public Task<PlanetModel[]> GetStarWarsPlanetsAsync()
    {
        return Task.FromResult(new PlanetModel[]
        {
            new PlanetModel
            {
                Name = "NamePlanet1"
            },
            new PlanetModel
            {
                Name = "NamePlanet2"
            }
        });
    }
    
    public Task<StarshipModel[]> GetStarWarsStarshipsAsync()
    {
        return GetStarWarsDataAsync<StarshipModel>(endpoints => endpoints.Starships);
    }
    
    public Task<FilmModel[]> GetStarWarsFilmsAsync()
    {
        return GetStarWarsDataAsync<FilmModel>(endpoints => endpoints.Films);
    }
    
    public Task<VehicleModel[]> GetStarWarsVehiclesAsync()
    {
        return GetStarWarsDataAsync<VehicleModel>(endpoints => endpoints.Vehicles);
    }
    
    public Task<SpecieModel[]> GetStarWarsSpeciesAsync()
    {
        return GetStarWarsDataAsync<SpecieModel>(endpoints => endpoints.Species);
    }
    
    private async Task<T[]> GetStarWarsDataAsync<T>(Func<SwapiEndpointsResponse, string> getUrl)
    {
        var swapiEndpointsResponse = await GetSwapiEndpointsAsync();
        if (swapiEndpointsResponse == null)
        {
            return null;
        }

        var url = getUrl(swapiEndpointsResponse);
        return await GetAsync<T[]>(url);
    }
    
    public Task<T> GetStarWarsDataSingleAsync<T>(string url)
    {
        return GetAsync<T>(url);
    }

    private async Task<SwapiEndpointsResponse> GetSwapiEndpointsAsync()
    {
        return await GetAsync<SwapiEndpointsResponse>(Constants.SwapiInfoUrl);
    }
}