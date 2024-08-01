namespace Domain {
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public Uri Link { get; set; }

        public Article(
            string id,
            string title,
            Uri link,
            TimeSpan createdAt,
            TimeSpan updatedAt
        ) : base(id, createdAt, updatedAt)
        {
            Title = title;
            Link = link;
        }
    }
}