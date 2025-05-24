using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;
using StarWars.Core.Services;
using StarWars.Core.Services.Abstract;

namespace StarWars.Core.ViewModels;

public sealed class CharactersViewModel : MvxViewModel
{
    private readonly IMvxNavigationService _navigationService;
    private readonly ISwapiService _swapiService;
    public IMvxAsyncCommand<CharacterViewModel> SelectCharacterCommand { get; }

    public CharactersViewModel(IMvxNavigationService navigationService, ISwapiService swapiService)
    {
        _navigationService = navigationService;
        _swapiService = swapiService;
        
        SelectCharacterCommand = new MvxAsyncCommand<CharacterViewModel>(OnCharacterSelectedAsync);
    }
    
    public ObservableCollection<CharacterViewModel> Characters { get; } = [];

    public override async Task Initialize()
    {
        await base.Initialize();

        var characters = await _swapiService.GetStarWarsCharactersAsync();
        
        Characters.ReplaceWith(characters.Select(x => new CharacterViewModel(x)));
    }
    
    private async Task OnCharacterSelectedAsync(CharacterViewModel character)
    {
        if (character != null)
        {
            await _navigationService.Navigate<CharacterDetailViewModel, CharacterModel>(character.Model);
        }
    }
}