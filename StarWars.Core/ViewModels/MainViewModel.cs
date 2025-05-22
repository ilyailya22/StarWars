using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWars.Core.Models;
using StarWars.Core.Services.Abstract;

namespace StarWars.Core.ViewModels;

public sealed class MainViewModel : MvxViewModel
{
    private readonly IMvxNavigationService _navigationService;
    private readonly ISwapiService _swapiService;
    public IMvxCommand<SwapiPersonModel> SelectPersonCommand { get; }

    public MainViewModel(IMvxNavigationService navigationService, ISwapiService swapiService)
    {
        _navigationService = navigationService;
        _swapiService = swapiService;
        
        SelectPersonCommand = new MvxCommand<SwapiPersonModel>(async person =>
        {
            if (person != null)
            {
                await navigationService.Navigate<DetailViewModel, SwapiPersonModel>(person);
            }
        });
    }
    
    private ObservableCollection<SwapiPersonModel> _people;
    public ObservableCollection<SwapiPersonModel> People
    {
        get => _people;
        set => SetProperty(ref _people, value);
    }

    private SwapiPersonModel _selectedPerson;

    public SwapiPersonModel SelectedPerson
    {
        get => _selectedPerson;
        set
        {
            if (SetProperty(ref _selectedPerson, value) && value != null)
            {
                _navigationService.Navigate<DetailViewModel, SwapiPersonModel>(value);
                SelectedPerson = null;
            }
        }
    }

    public override async Task Initialize()
    {
        await base.Initialize();

        var people = await _swapiService.GetStarWarsPeopleAsync();
        
        People = new ObservableCollection<SwapiPersonModel>(people);
    }
}