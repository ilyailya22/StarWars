using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;

namespace StarWars.Core.ViewModels;

public sealed class DetailViewModel : MvxViewModel<SwapiPersonModel>
{
    private readonly IMvxNavigationService _navigationService;
    public IMvxAsyncCommand GoBackCommand { get; }

    public DetailViewModel(IMvxNavigationService navigationService)
    {
        _navigationService = navigationService;
        GoBackCommand = new MvxAsyncCommand(GoBack);
    }

    public SwapiPersonModel Person { get; private set; }

    public override void Prepare(SwapiPersonModel parameter)
    {
        Person = parameter;
    }
    
    private async Task GoBack()
    {
        await _navigationService.Close(this);
    }
}