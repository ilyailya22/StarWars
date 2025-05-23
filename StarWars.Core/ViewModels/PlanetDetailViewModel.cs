using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;

namespace StarWars.Core.ViewModels;

public sealed class PlanetDetailViewModel : MvxViewModel<PlanetModel>
{
    private readonly IMvxNavigationService _navigationService;
    public IMvxAsyncCommand GoBackCommand { get; }

    public PlanetDetailViewModel(IMvxNavigationService navigationService)
    {
        _navigationService = navigationService;
        GoBackCommand = new MvxAsyncCommand(GoBack);
    }

    public PlanetModel Planet { get; private set; }

    public override void Prepare(PlanetModel parameter)
    {
        Planet = parameter;
    }
    
    private async Task GoBack()
    {
        await _navigationService.Close(this);
    }
}