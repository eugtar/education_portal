namespace Application
{
    public class UpdateArticleDto
    {
        public string? Title { get; set; }
        public Uri? Link { get; set; }

        public UpdateArticleDto(string? title, Uri? link)
        {
            Title = title;
            Link = link;
        }
    }
}