namespace Domain
{
    public class CreateVideoDto
    {
        public string Title { get; set; }
        public TimeOnly Duration { get; set; }
        public VideoQuality Quality { get; set; }

        public CreateVideoDto(
            string title,
            TimeOnly duration,
            VideoQuality quality
        )
        {
            Title = title;
            Duration = duration;
            Quality = quality;
        }
    }
}
