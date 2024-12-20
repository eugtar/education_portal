namespace Application.Dtos.AuthDtos;

public sealed class SignUpDto
{
    private string _firstName = null!;
    private string _lastName = null!;
    private string _email = null!;
    private string _password = null!;
    public required string FirstName
    {
        get => _firstName;
        set => _firstName = value.Trim().ToLower();
    }
    public required string LastName
    {
        get => _lastName;
        set => _lastName = value.Trim().ToLower();
    }
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
