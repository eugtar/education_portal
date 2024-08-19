﻿namespace Application.Dtos;

public class CreateUserDto(string firstName, string lastName, string email, string password)
{
    public string FirstName => firstName;
    public string LastName => lastName;
    public string Email => email;
    public string Password => password;
}
