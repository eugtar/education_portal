using Domain;

namespace Application
{
    public class CreateEBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageAmount { get; set; }
        public EBookFormat Format { get; set; }
        public DateTime PublishedOn { get; set; }

        public CreateEBookDto(
            string title,
            string author,
            int pageAmount,
            EBookFormat format,
            DateTime publishedOn
        )
        {
            Title = title;
            Author = author;
            PageAmount = pageAmount;
            Format = format;
            PublishedOn = publishedOn;
        }
    }
}
