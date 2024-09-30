using System.Reflection;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class DatabaseContext : DbContext
{
    public virtual DbSet<Material> Materials { get; set; } = null!;
    public virtual DbSet<Article> Articles { get; set; } = null!;
    public virtual DbSet<Ebook> Ebooks { get; set; } = null!;
    public virtual DbSet<Video> Videos { get; set; } = null!;
    public virtual DbSet<Quality> Qualities { get; set; } = null!;
    public virtual DbSet<Format> Formats { get; set; } = null!;
    public virtual DbSet<Course> Courses { get; set; } = null!;
    public virtual DbSet<Skill> Skills { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<UserCourse> UserCourses { get; set; } = null!;
    public virtual DbSet<UserSkill> UserSkills { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
