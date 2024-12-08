namespace Application.Dtos;

public sealed class ForgotPasswordDto(string email)
{
    public string Email => email.Trim().ToLower();
}
