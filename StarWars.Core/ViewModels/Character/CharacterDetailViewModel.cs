using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;
using StarWars.Core.Services.Abstract;
using StarWars.Core.ViewModels.Planet;

namespace StarWars.Core.ViewModels.Character;

public sealed class CharacterDetailViewModel(IMvxNavigationService navigationService, ISwapiService swapiService) : MvxViewModel<CharacterModel>
{
    private IMvxAsyncCommand _goBackCommand;
    public IMvxAsyncCommand GoBackCommand => _goBackCommand ??= new MvxAsyncCommand(GoBack);

    private IMvxAsyncCommand<PlanetItemViewModel> _selectPlanetCommand;
    public IMvxAsyncCommand<PlanetItemViewModel> SelectPlanetCommand => _selectPlanetCommand ??= new MvxAsyncCommand<PlanetItemViewModel>(OnPlanetSelectedAsync);

    private CharacterModel _characterModel;
    private CharacterViewModel _character;
    public CharacterViewModel Character
    {
        get => _character;
        private set => SetProperty(ref _character, value);
    }

    public override void Prepare(CharacterModel character)
    {
        _characterModel = character;
    }

    public override async Task Initialize()
    {
        await base.Initialize();
        
        var planetTask = swapiService.GetStarWarsDataSingleAsync<PlanetModel>(_characterModel.Homeworld);
        
        await Task.WhenAll(planetTask);

        var planet = planetTask.Result;

        Character = new CharacterViewModel
        {
            Name = _characterModel.Name,
            Height = _characterModel.Height,
            Mass = _characterModel.Mass,
            HairColor = _characterModel.HairColor,
            SkinColor = _characterModel.SkinColor,
            EyeColor = _characterModel.EyeColor,
            BirthYear = _characterModel.BirthYear,
            Gender = _characterModel.Gender,
            Homeworld = new PlanetItemViewModel
            {
                Name = planet.Name,
                Model = planet
            },
            Created = _characterModel.Created,
            Edited = _characterModel.Edited
        };
    }

    private Task<bool> GoBack()
    {
        return navigationService.Navigate<CharactersViewModel>();
    }
    
    private async Task OnPlanetSelectedAsync(PlanetItemViewModel planet)
    {
        if (planet != null)
        {
            await navigationService.Navigate<PlanetDetailViewModel, PlanetModel>(planet.Model);
        }
    }
}