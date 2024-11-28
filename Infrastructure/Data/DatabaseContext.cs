using System.Reflection;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.RoleGroup;
using Domain.Entities.UserGroup;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Data;

public partial class DatabaseContext
    : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Seed();
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
