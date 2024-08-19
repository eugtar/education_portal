using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Article> Articles { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<EBook> EBooks { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Video> Videos { get; set; } = null!;
    public DbSet<UserCourse> UserCourses { get; set; } = null!;
    public DbSet<UserSkill> UserSkills { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EBook>().Property(e => e.Format).HasConversion<int>();
        modelBuilder.Entity<Video>().Property(e => e.Quality).HasConversion<int>();
        // modelBuilder.Entity<UserCourse>().HasKey(e => new { e.UserId, e.CourseId });
    }

    /*     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetFileLoadExceptionHandler((error) => Console.WriteLine(error.Exception.Message))
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Trace);
        } */
}

