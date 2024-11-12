namespace Application.Dtos;

public sealed class CreateUserCourseDto
{
    public bool Finished { get; set; } = false;
    public decimal Progress { get; set; } = 0M;
}
