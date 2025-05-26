using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;
using StarWars.Core.Services.Abstract;

namespace StarWars.Core.ViewModels.Planet;

public sealed class PlanetsViewModel(IMvxNavigationService navigationService, ISwapiService swapiService) : MvxViewModel
{
    private IMvxAsyncCommand<PlanetItemViewModel> _selectPlanetCommand;
    public IMvxAsyncCommand<PlanetItemViewModel> SelectPlanetCommand => _selectPlanetCommand ??= new MvxAsyncCommand<PlanetItemViewModel>(OnPlanetSelectedAsync);

    public MvxObservableCollection<PlanetItemViewModel> PlanetItems { get; } = [];

    public override async Task Initialize()
    {
        await base.Initialize();

        var planets = await swapiService.GetStarWarsPlanetsAsync();
        
        PlanetItems.ReplaceWith(planets.Select(x => new PlanetItemViewModel
        {
            Name = x.Name,
            Model = x
        }));
    }
    
    private async Task OnPlanetSelectedAsync(PlanetItemViewModel planet)
    {
        if (planet != null)
        {
            await navigationService.Navigate<PlanetDetailViewModel, PlanetModel>(planet.Model);
        }
    }
}