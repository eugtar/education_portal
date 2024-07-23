namespace Domain {
    public class Video : BaseEntity<string>
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

        public void Deconstruct(
            out string id,
            out string title,
            out TimeOnly duration,
            out VideoQuality quality,
            out TimeSpan createdAt,
            out TimeSpan updatedAt
        )
        {
            base.Deconstruct(out id, out createdAt, out updatedAt);
            title = Title;
            duration = Duration;
            quality = Quality;
        }
    }
}