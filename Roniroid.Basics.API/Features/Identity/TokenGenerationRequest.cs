using System.Text.Json.Serialization;

namespace Roniroid.Basics.API;

public class TokenGenerationRequest
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("customClaims")]
    public Dictionary<string, System.Text.Json.JsonElement> CustomClaims { get; set; }
}
