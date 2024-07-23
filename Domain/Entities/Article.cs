namespace Domain {
    public class Article : BaseEntity<string>
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

        public void Deconstruct(
            out string id,
            out string title,
            out Uri link,
            out TimeSpan createdAt,
            out TimeSpan updatedAt

        )
        {
            base.Deconstruct(out id, out createdAt, out updatedAt);
            title = Title;
            link = Link;
        }
    }
}