namespace Domain {
    public class Video : BaseEntity
    {
        public string Title { get; set; }
        public TimeOnly Duration { get; set; }
        public VideoQuality Quality { get; set; }

        public Video(
            string id,
            string title,
            TimeOnly duration,
            VideoQuality quality,
            TimeSpan createdAt,
            TimeSpan updatedAt
        ) : base(id, createdAt, updatedAt)
        {
            Title = title;
            Duration = duration;
            Quality = quality;
        }
    }
}