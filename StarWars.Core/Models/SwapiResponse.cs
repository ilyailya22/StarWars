using Newtonsoft.Json;

namespace StarWars.Core.Models;

public sealed class SwapiResponse
{
    [JsonProperty("films")]
    public string Films { get; set; }
    
    [JsonProperty("people")]
    public string People { get; set; }
    
    [JsonProperty("planets")]
    public string Planets { get; set; }
    
    [JsonProperty("species")]
    public string Species { get; set; }
    
    [JsonProperty("vehicles")]
    public string Vehicles { get; set; }
    
    [JsonProperty("starships")]
    public string Starships { get; set; }
}