namespace Application.Dtos;

public sealed class SignInDto
(
    string email,
    string password
)
{
    public string Email => email.Trim().ToLower();
    public string Password => password.Trim();
}
