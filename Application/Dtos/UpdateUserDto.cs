namespace Application
{
    public class UpdateUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public UpdateUserDto(
            string? firstName,
            string? lastName
        )
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}