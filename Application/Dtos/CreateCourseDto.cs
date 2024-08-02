namespace Application
{
    public class CreateCourseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public CreateCourseDto(
            string title,
            string description
        )
        {
            Title = title;
            Description = description;
        }
    }
}
