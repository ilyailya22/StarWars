using MvvmCross.ViewModels;
using StarWars.Core.Models;

namespace StarWars.Core.ViewModels.Planet;

public sealed class PlanetItemViewModel : MvxNotifyPropertyChanged
{
    public string Name { get; set; }
    public PlanetModel Model { get; set; } 
}