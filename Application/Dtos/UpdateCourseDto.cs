namespace Application
{
    public class UpdateCourseDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public UpdateCourseDto(
            string? title,
            string? description
        )
        {
            Title = title;
            Description = description;
        }
    }
}