﻿using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;
using StarWars.Core.ViewModels.Character;

namespace StarWars.Core.ViewModels.Planet;

public sealed class PlanetViewModel : MvxNotifyPropertyChanged
{
    public string Name { get; set; }
    public string RotationPeriod { get; set; }
    public string OrbitalPeriod { get; set; }
    public string Diameter { get; set; }
    public string Climate { get; set; }
    public string Gravity { get; set; }
    public string Terrain { get; set; }
    public string SurfaceWater { get; set; }
    public string Population { get; set; }
    public CharacterItemViewModel[] Residents { get; set; }
    public List<string> Films { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
}