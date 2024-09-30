namespace Application.Dtos;

public class UpdateUserDto(
    string? firstName = null,
    string? lastName = null,
    string? email = null,
    string? hashPassword = null
    )
{
    public string? FirstName => firstName;
    public string? LastName => lastName;
    public string? Email => email;
    public string? HashPassword => hashPassword;
}
