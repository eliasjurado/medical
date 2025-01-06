using System.Text.Json.Serialization;

namespace Medical.Domain.Dto.Auth;

public class RefreshTokenRequest
{
    [JsonIgnore]
    public string? RefreshToken { get; set; } = string.Empty;

    public string CurrentToken { get; set; } = string.Empty;
}
