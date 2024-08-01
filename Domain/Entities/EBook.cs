namespace Domain {
    public class EBook : BaseEntity
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
    }
}