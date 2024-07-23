namespace Domain {
    public class EBook : BaseEntity<string>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageAmount { get; set; }
        public EBookFormat Format { get; set; }
        public DateTime PublishedOn { get; set; }

        public EBook(
            string id,
            string title,
            string author,
            int pageAmount,
            EBookFormat format,
            DateTime publishedOn,
            TimeSpan createdAt,
            TimeSpan updatedAt
        ) : base(id, createdAt, updatedAt)
        {
            Title = title;
            Author = author;
            PageAmount = pageAmount;
            Format = format;
            PublishedOn = publishedOn;
        }

        public void Deconstruct(
            out string id,
            out string title,
            out string author,
            out int pageAmount,
            out EBookFormat format,
            out DateTime publishedOn,
            out TimeSpan createdAt,
            out TimeSpan updatedAt
        )
        {
            base.Deconstruct(out id, out createdAt, out updatedAt);
            title = Title;
            author = Author;
            pageAmount = PageAmount;
            format = Format;
            publishedOn = PublishedOn;
        }
    }
}