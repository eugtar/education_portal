using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;
    public IFormatRepository Formats => new FormatRepository(_context);
    public IQualityRepository Qualities => new QualityRepository(_context);
    public IArticleRepository Articles => new ArticleRepository(_context);
    public IEbookRepository Ebooks => new EbookRepository(_context);
    public IVideoRepository Videos => new VideoRepository(_context);
    public IRewardRepository Rewards => new RewardRepository(_context);
    public ILessonRepository Lessons => new LessonRepository(_context);
    public ICourseRepository Courses => new CourseRepository(_context);
    public ISkillRepository Skills => new SkillRepository(_context);
    public IUserRepository Users => new UserRepository(_context);

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
