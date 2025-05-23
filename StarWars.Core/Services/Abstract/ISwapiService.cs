using System.Threading.Tasks;
using StarWars.Core.Models;

namespace StarWars.Core.Services.Abstract;

public interface ISwapiService
{
    Task<CharacterModel[]> GetStarWarsCharactersAsync();

    Task<PlanetModel[]> GetStarWarsPlanetsAsync();
}