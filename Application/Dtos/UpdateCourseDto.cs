namespace Application.Dtos;

public class UpdateCourseDto(
    bool? finished = null,
    decimal? progress = null
)
{
    public bool? Finished => finished;
    public decimal? Progress => progress;
}
