namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository Users { get; }
    public ICourseRepository Courses { get; }
    public IUserCourseRepository UserCourses { get; }
    public IArticleRepository Articles { get; }
    public IEBookRepository EBooks { get; }
    public IVideoRepository Videos { get; }
    public ISkillRepository Skills { get; }
    public int Complete();
}
