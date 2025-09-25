using System.Text.Json.Serialization;

namespace _3dPrintManager.Models;

public class EnclosureModuleStatusDto
{
    [JsonIgnore]
    public string Ip { get; set; }

    [JsonPropertyName("moduleName")]
    public string ModuleName { get; set; }

    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }

    [JsonPropertyName("humidity")]
    public double Humidity { get; set; }

    [JsonPropertyName("fanStatus")]
    public bool FanOn { get; set; }

    [JsonPropertyName("ledStatus")]
    public bool LedOn { get; set; }
}