using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;

namespace StarWars.Core.ViewModels;

public sealed class CharacterDetailViewModel : MvxViewModel<CharacterModel>
{
    private readonly IMvxNavigationService _navigationService;
    public IMvxAsyncCommand GoBackCommand { get; }

    public CharacterDetailViewModel(IMvxNavigationService navigationService)
    {
        _navigationService = navigationService;
        GoBackCommand = new MvxAsyncCommand(GoBack);
    }

    public CharacterModel Character { get; private set; }

    public override void Prepare(CharacterModel parameter)
    {
        Character = parameter;
    }
    
    private async Task GoBack()
    {
        await _navigationService.Close(this);
    }
}