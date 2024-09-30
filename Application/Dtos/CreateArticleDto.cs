namespace Application
{
    public class CreateArticleDto
    {
        public string Title { get; set; }
        public Uri Link { get; set; }

        public CreateArticleDto(string title, Uri link)
        {
            Title = title;
            Link = link;
        }
    }
}
