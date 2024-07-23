namespace Domain {
    public class Course : BaseEntity<string>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<EBook> BookMaterials { get; private set; }
        public List<Article> ArticleMaterials { get; private set; }
        public List<Video> VideoMaterials { get; private set; }
        public List<Skill> Skills { get; private set; }

        public Course(
            string id,
            string title,
            string description,
            List<EBook> bookMaterials,
            List<Article> articleMaterials,
            List<Video> videoMaterials,
            List<Skill> skills,
            TimeSpan createdAt,
            TimeSpan updatedAt
        ) : base(id, createdAt, updatedAt)
        {
            Title = title;
            Description = description;
            BookMaterials = bookMaterials;
            ArticleMaterials = articleMaterials;
            VideoMaterials = videoMaterials;
            Skills = skills;
        }

        public void Deconstruct(
            out string id,
            out string title,
            out string description,
            out List<EBook> bookMaterials,
            out List<Article> articleMaterials,
            out List<Video> videoMaterials,
            out List<Skill> skills,
            out TimeSpan createdAt,
            out TimeSpan updatedAt
        )
        {
            base.Deconstruct(out id, out createdAt, out updatedAt);
            title = Title;
            description = Description;
            bookMaterials = BookMaterials;
            articleMaterials = ArticleMaterials;
            videoMaterials = VideoMaterials;
            skills = Skills;
        }
    }
}