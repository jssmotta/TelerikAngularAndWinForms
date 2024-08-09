using System.Text.Json.Serialization;

namespace app_winforsm;
public class Message
{
    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("value")]
    public int Value { get; set; }
}