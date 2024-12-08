namespace Application.Dtos;

public sealed class SignUpDto
(
    string firstName,
    string lastName,
    string email,
    string password
)
{
    public string FirstName => firstName.Trim().ToLower();
    public string LastName => lastName.Trim().ToLower();
    public string Email => email.Trim().ToLower();
    public string Password => password.Trim();
}
