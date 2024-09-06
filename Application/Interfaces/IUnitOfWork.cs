namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IFormatRepository Formats { get; }
    public IQualityRepository Qualities { get; }
    public IArticleRepository Articles { get; }
    public IEbookRepository Ebooks { get; }
    public IVideoRepository Videos { get; }
    public ISkillRepository Skills { get; }
    public ICourseRepository Courses { get; }
    public IUserCourseRepository UserCourses { get; }
    public IUserSkillRepository UserSkills { get; }
    public IUserRepository Users { get; }
    public int Complete();
}
