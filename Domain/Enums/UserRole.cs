using System.ComponentModel;

namespace Domain.Enums;

public enum UserRole
{
    [Description("Administrator")]
    Admin = 1,
    [Description("Theacher")]
    Teacher = 2,
    [Description("Student")]
    Student = 3,
    [Description("Guest")]
    Guest = 4,
}
