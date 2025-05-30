using System.Threading.Tasks;
using StarWars.Core.Models;

namespace StarWars.Core.Services.Abstract;

public interface ISwapiService
{
    Task<CharacterModel[]> GetStarWarsCharactersAsync();

    Task<PlanetModel[]> GetStarWarsPlanetsAsync();
    
    Task<StarshipModel[]> GetStarWarsStarshipsAsync();
    
    Task<VehicleModel[]> GetStarWarsVehiclesAsync();

    Task<FilmModel[]> GetStarWarsFilmsAsync();
    
    Task<SpecieModel[]> GetStarWarsSpeciesAsync();

    Task<T> GetStarWarsDataSingleAsync<T>(string url);
}