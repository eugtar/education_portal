using Domain.Entities;
using Infrastructure.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class DatabaseContext : DbContext
{
    public virtual DbSet<Article> Articles { get; set; } = null!;
    public virtual DbSet<Course> Courses { get; set; } = null!;
    public virtual DbSet<Ebook> Ebooks { get; set; } = null!;
    public virtual DbSet<Format> Formats { get; set; } = null!;
    public virtual DbSet<Lesson> Lessons { get; set; } = null!;
    public virtual DbSet<Quality> Qualities { get; set; } = null!;
    public virtual DbSet<Reward> Rewards { get; set; } = null!;
    public virtual DbSet<Skill> Skills { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Video> Videos { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-C0UIRG5;Initial Catalog=edu_db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FormatConfiguration());
        modelBuilder.ApplyConfiguration(new QualityConfiguration());
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        modelBuilder.ApplyConfiguration(new EBookConfiguration());
        modelBuilder.ApplyConfiguration(new VideoConfiguration());
        modelBuilder.ApplyConfiguration(new RewardConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new SkillConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
