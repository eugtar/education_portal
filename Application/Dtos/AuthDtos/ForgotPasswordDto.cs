namespace Application.Dtos.AuthDtos;

public sealed class ForgotPasswordDto
{
    private string _email = null!;
    public required string Email
    {
        get => _email;
        set => _email = value.Trim().ToLower();
    }
}
