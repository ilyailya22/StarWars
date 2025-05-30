using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;
using StarWars.Core.Services.Abstract;

namespace StarWars.Core.ViewModels.Character;

public sealed class CharactersViewModel(IMvxNavigationService navigationService, ISwapiService swapiService) : MvxViewModel
{
    private IMvxAsyncCommand<CharacterItemViewModel> _selectCharacterCommand;
    public IMvxAsyncCommand<CharacterItemViewModel> SelectCharacterCommand => _selectCharacterCommand ??= new MvxAsyncCommand<CharacterItemViewModel>(OnCharacterSelectedAsync);

    public MvxObservableCollection<CharacterItemViewModel> CharacterItems { get; } = [];

    public override async Task Initialize()
    {
        await base.Initialize();

        var characters = await swapiService.GetStarWarsCharactersAsync();
        
        CharacterItems.ReplaceWith(characters.Select(x => new CharacterItemViewModel
        {
            Name = x.Name,
            Model = x
        }));
    }
    
    private async Task OnCharacterSelectedAsync(CharacterItemViewModel characterItem)
    {
        if (characterItem != null)
        {
            await navigationService.Navigate<CharacterDetailViewModel, CharacterModel>(characterItem.Model);
        }
    }
}