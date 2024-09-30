using Domain;

namespace Application
{
    public class UpdateVideoDto
    {
        public string? Title { get; set; }
        public TimeOnly? Duration { get; set; }
        public VideoQuality? Quality { get; set; }

        public UpdateVideoDto(
            string? title,
            TimeOnly? duration,
            VideoQuality? quality
        )
        {
            Title = title;
            Duration = duration;
            Quality = quality;
        }
    }
}