using System.Text.Json.Serialization;

namespace _3dPrintManager.Models;

public class ModuleData
{
    [JsonPropertyName("moduleName")]
    public string ModuleName { get; set; }

    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }

    [JsonPropertyName("humidity")]
    public double Humidity { get; set; }

    [JsonPropertyName("fanStatus")]
    public bool FanOn { get; set; }

    [JsonPropertyName("ledOn")]
    [JsonIgnore]
    public bool LedOn { get; set; }
}