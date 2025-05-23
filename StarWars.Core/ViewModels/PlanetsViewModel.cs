using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;
using StarWars.Core.Services;
using StarWars.Core.Services.Abstract;

namespace StarWars.Core.ViewModels;

public sealed class PlanetsViewModel : MvxViewModel
{
    private readonly IMvxNavigationService _navigationService;
    private readonly ISwapiService _swapiService;
    public IMvxAsyncCommand<PlanetModel> SelectPlanetCommand { get; }

    public PlanetsViewModel(IMvxNavigationService navigationService, ISwapiService swapiService)
    {
        _navigationService = navigationService;
        _swapiService = swapiService;
        
        SelectPlanetCommand = new MvxAsyncCommand<PlanetModel>(async planet =>
        {
            if (planet != null)
            {
                await navigationService.Navigate<PlanetDetailViewModel, PlanetModel>(planet);
            }
        });
    }
    
    public ObservableCollection<PlanetModel> Planets { get; } = [];

    private PlanetModel _selectedPlanet;

    public PlanetModel SelectedPlanet
    {
        get => _selectedPlanet;
        set
        {
            if (SetProperty(ref _selectedPlanet, value) && value != null)
            {
                _navigationService.Navigate<PlanetDetailViewModel, PlanetModel>(value);
                SelectedPlanet = null;
            }
        }
    }

    public override async Task Initialize()
    {
        await base.Initialize();

        var planets = await _swapiService.GetStarWarsPlanetsAsync();
        
        Planets.ReplaceWith(planets);
    }
}