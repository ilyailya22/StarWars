using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.ViewModels.Character;
using StarWars.Core.ViewModels.Planet;

namespace StarWars.Core.ViewModels;

public sealed class MainViewModel(IMvxNavigationService navigationService) : MvxViewModel
{
    private IMvxAsyncCommand _selectCharactersViewCommand;
    public IMvxAsyncCommand SelectCharactersViewCommand => _selectCharactersViewCommand ??= new MvxAsyncCommand(OnCharacterSelectedAsync);

    private IMvxAsyncCommand _selectPlanetsViewCommand;
    public IMvxAsyncCommand SelectPlanetsViewCommand => _selectPlanetsViewCommand ??= new MvxAsyncCommand(OnPlanetSelectedAsync);

    public override async Task Initialize()
    {
        await base.Initialize();
    }
    
    private Task OnCharacterSelectedAsync()
    {
        return navigationService.Navigate<CharactersViewModel>();
    }
    
    private Task OnPlanetSelectedAsync()
    {
        return navigationService.Navigate<PlanetsViewModel>();
    }
}