using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace StarWars.Core.ViewModels;

public sealed class MainViewModel(IMvxNavigationService navigationService) : MvxViewModel
{
    public override async Task Initialize()
    {
        await base.Initialize();
    }

    public override void ViewAppeared()
    {
        base.ViewAppeared();
        navigationService.Navigate<CharactersViewModel>();
    }
}