namespace Application
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreateUserDto(
            string firstName,
            string lastName
        ) 
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
