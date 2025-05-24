using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;
using StarWars.Core.Models;

namespace StarWars.Core.ViewModels;

public class CharacterViewModel(CharacterModel model) : MvxNotifyPropertyChanged
{
    public CharacterModel Model { get; } = model;

    public string Name => Model.Name;
    public string Height => Model.Height;
    public string Mass => Model.Mass;
    public string HairColor => Model.HairColor;
    public string SkinColor => Model.SkinColor;
    public string EyeColor => Model.EyeColor;
    public string BirthYear => Model.BirthYear;
    public string Gender => Model.Gender;
    public string Homeworld => Model.Homeworld;
    public List<string> Films => Model.Films;
    public List<string> Species => Model.Species;
    public List<string> Vehicles => Model.Vehicles;
    public List<string> Starships => Model.Starships;
    public DateTime Created => Model.Created;
    public DateTime Edited => Model.Edited;
    public string Url => Model.Url;
}