using MvvmCross.ViewModels;
using StarWars.Core.Models;

namespace StarWars.Core.ViewModels.Character;

public sealed class CharacterItemViewModel : MvxNotifyPropertyChanged
{
    public string Name { get; set; }
    public CharacterModel Model { get; set; } 
}