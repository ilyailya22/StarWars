using System.Collections.ObjectModel;
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
    public IMvxAsyncCommand<CharacterModel> SelectCharacterCommand { get; }

    public CharactersViewModel(IMvxNavigationService navigationService, ISwapiService swapiService)
    {
        _navigationService = navigationService;
        _swapiService = swapiService;
        
        SelectCharacterCommand = new MvxAsyncCommand<CharacterModel>(async character =>
        {
            if (character != null)
            {
                await navigationService.Navigate<CharacterDetailViewModel, CharacterModel>(character);
            }
        });
    }
    
    public ObservableCollection<CharacterModel> Characters { get; } = [];

    private CharacterModel _selectedCharacter;

    public CharacterModel SelectedCharacter
    {
        get => _selectedCharacter;
        set
        {
            if (SetProperty(ref _selectedCharacter, value) && value != null)
            {
                _navigationService.Navigate<CharacterDetailViewModel, CharacterModel>(value);
                SelectedCharacter = null;
            }
        }
    }

    public override async Task Initialize()
    {
        await base.Initialize();

        var characters = await _swapiService.GetStarWarsCharactersAsync();
        
        Characters.ReplaceWith(characters);
    }
}