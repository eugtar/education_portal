using System.Reflection;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class DatabaseContext : IdentityDbContext<User, Role, int>
{
    public virtual DbSet<Quality> Qualities { get; set; } = null!;
    public virtual DbSet<Format> Formats { get; set; } = null!;
    public virtual DbSet<Material> Materials { get; set; } = null!;
    public virtual DbSet<Article> Articles { get; set; } = null!;
    public virtual DbSet<Ebook> Ebooks { get; set; } = null!;
    public virtual DbSet<Video> Videos { get; set; } = null!;
    public virtual DbSet<Course> Courses { get; set; } = null!;
    public virtual DbSet<Skill> Skills { get; set; } = null!;
    public virtual DbSet<UserCourse> UserCourses { get; set; } = null!;
    public virtual DbSet<UserSkill> UserSkills { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);

        // modelBuilder.Seed();
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
                if (entity.Entity is BaseEntity baseEntityCreate)
                {
                    baseEntityCreate.CreatedAt = dateTimeNow;
                }

                if (entity.Entity is User userCreate)
                {
                    userCreate.CreatedAt = dateTimeNow;
                }

                if (entity.Entity is Role roleCreate)
                {
                    roleCreate.CreatedAt = dateTimeNow;
                }
            }

            if (entity.Entity is BaseEntity baseEntityUpdate)
            {
                baseEntityUpdate.UpdatedAt = dateTimeNow;
            }

            if (entity.Entity is User userUpdate)
            {
                userUpdate.UpdatedAt = dateTimeNow;
            }

            if (entity.Entity is Role roleUpdate)
            {
                roleUpdate.UpdatedAt = dateTimeNow;
            }
        }
    }
}
