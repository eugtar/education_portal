namespace Application.Dtos.AuthDtos;

public sealed class RefreshTokenDto
{
    private string _refreshToken = null!;
    public required string RefreshToken
    {
        get => _refreshToken;
        set => _refreshToken = value.Trim();
    }
}
