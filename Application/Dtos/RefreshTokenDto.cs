namespace Application.Dtos;

public sealed class RefreshTokenDto(string refreshToken)
{
    public string RefreshToken => refreshToken.Trim();
}
