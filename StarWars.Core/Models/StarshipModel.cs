using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StarWars.Core.Models;

public sealed class StarshipModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; }

    [JsonPropertyName("cost_in_credits")]
    public string CostInCredits { get; set; }

    [JsonPropertyName("length")]
    public string Length { get; set; }

    [JsonPropertyName("max_atmosphering_speed")]
    public string MaxAtmospheringSpeed { get; set; }

    [JsonProperty("crew")]
    public string Crew { get; set; }

    [JsonProperty("passengers")]
    public string Passengers { get; set; }

    [JsonProperty("cargo_capacity")]
    public string CargoCapacity { get; set; }

    [JsonProperty("consumables")]
    public string Consumables { get; set; }

    [JsonProperty("hyperdrive_rating")]
    public string HyperdriveRating { get; set; }

    [JsonProperty("MGLT")]
    public string MGLT { get; set; }

    [JsonProperty("starship_class")]
    public string StarshipClass { get; set; }

    [JsonProperty("pilots")]
    public List<string> Pilots { get; set; }

    [JsonProperty("films")]
    public List<string> Films { get; set; }

    [JsonProperty("created")]
    public DateTime Created { get; set; }

    [JsonProperty("edited")]
    public DateTime Edited { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}