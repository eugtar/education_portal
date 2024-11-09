using System.Reflection;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class DatabaseContext : DbContext
{
    public virtual DbSet<Material> Materials { get; set; }
    public virtual DbSet<Article> Articles { get; set; }
    public virtual DbSet<Ebook> Ebooks { get; set; }
    public virtual DbSet<Video> Videos { get; set; }
    public virtual DbSet<Quality> Qualities { get; set; }
    public virtual DbSet<Format> Formats { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Skill> Skills { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserCourse> UserCourses { get; set; }
    public virtual DbSet<UserSkill> UserSkills { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Seed();

        OnModelCreatingPartial(modelBuilder);
    }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var dateTimeNow = DateTime.UtcNow;
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedAt = dateTimeNow;
            }
                ((BaseEntity)entity.Entity).UpdatedAt = dateTimeNow;
        }
    }
}
