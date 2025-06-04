using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;
using StarWars.Core.Services.Abstract;
using StarWars.Core.ViewModels.Character;

namespace StarWars.Core.ViewModels.Planet;

public sealed class PlanetDetailViewModel(IMvxNavigationService navigationService, ISwapiService swapiService) : MvxViewModel<PlanetModel>
{
    private IMvxAsyncCommand _goBackCommand;
    public IMvxAsyncCommand GoBackCommand => _goBackCommand ??= new MvxAsyncCommand(GoBack);

    private IMvxAsyncCommand<CharacterModel> _selectCharacterCommand;
    public IMvxAsyncCommand<CharacterModel> SelectCharacterCommand => _selectCharacterCommand ??= new MvxAsyncCommand<CharacterModel>(OnCharacterSelectedAsync);

    private PlanetModel _planetModel;
    
    private PlanetViewModel _planet;
    public PlanetViewModel Planet
    {
        get => _planet;
        private set => SetProperty(ref _planet, value);
    }

    public override void Prepare(PlanetModel planet)
    {
        _planetModel = planet;
    }

    public override async Task Initialize()
    {
        await base.Initialize();
        var characterTasks = _planetModel.Residents.Select(swapiService.GetStarWarsDataSingleAsync<CharacterModel>);
            
        var charactersArray = await Task.WhenAll(characterTasks);
        Planet = new PlanetViewModel
        {
            Name = _planetModel.Name,
            RotationPeriod = _planetModel.RotationPeriod,
            OrbitalPeriod = _planetModel.OrbitalPeriod,
            Diameter = _planetModel.Diameter,
            Climate = _planetModel.Climate,
            Gravity = _planetModel.Gravity,
            Terrain = _planetModel.Terrain,
            SurfaceWater = _planetModel.SurfaceWater,
            Population = _planetModel.Population,
            Residents = charactersArray.Select(x => new CharacterItemViewModel
            {
                Name = x.Name,
                Model = x
            }).ToArray(),
            Created = _planetModel.Created,
            Edited = _planetModel.Edited,
        };
    }

    private Task<bool> GoBack()
    {
        return navigationService.Close(this);
    }
    
    private async Task OnCharacterSelectedAsync(CharacterModel character)
    {
        if (character != null)
        {
            await navigationService.Navigate<CharacterDetailViewModel, CharacterModel>(character);
        }
    }
}