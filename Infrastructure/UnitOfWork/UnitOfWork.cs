using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;
    public IUserRepository Users => new UserRepository(_context);
    public ICourseRepository Courses => new CourseRepository(_context);
    public IUserCourseRepository UserCourses => new UserCourseRepository(_context);
    public IArticleRepository Articles => new ArticleRepository(_context);
    public IEBookRepository EBooks => new EBookRepository(_context);
    public IVideoRepository Videos => new VideoRepository(_context);
    public ISkillRepository Skills => new SkillRepository(_context);
    public IUserSkillRepository UserSkills => new UserSkillRepository(_context);

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
