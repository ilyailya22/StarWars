using System;
using MvvmCross.ViewModels;
using StarWars.Core.ViewModels.Planet;

namespace StarWars.Core.ViewModels.Character;

public sealed class CharacterViewModel : MvxNotifyPropertyChanged
{
    public string Name { get; set; }
    public string Height { get; set; }
    public string Mass { get; set; }
    public string HairColor { get; set; }
    public string SkinColor { get; set; }
    public string EyeColor { get; set; }
    public string BirthYear { get; set; }
    public string Gender { get; set; }
    public PlanetItemViewModel Homeworld { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
}