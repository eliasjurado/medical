using System.Text.Json.Serialization;

namespace Medical.Domain.Dto.Auth;

public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;

    [JsonIgnore]
    public string? RefreshToken { get; set; } = string.Empty;
}
