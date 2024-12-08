namespace Application.Dtos;

public sealed class PasswordResetDto(
    string email,
    string confirmationToken,
    string password
)
{
    public string Email => email.ToLower().Trim();
    public string ConfirmationToken => confirmationToken.Trim();
    public string Password => password.Trim();
}
