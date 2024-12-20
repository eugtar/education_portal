namespace Application.Dtos.AuthDtos;

public sealed class SignInDto
{
    private string _email = null!;
    private string _password = null!;
    public required string Email
    {
        get => _email;
        set => _email = value.Trim().ToLower();
    }
    public required string Password
    {
        get => _password;
        set => _password = value.Trim();
    }
}
