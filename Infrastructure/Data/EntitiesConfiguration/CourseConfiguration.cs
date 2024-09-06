using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class LessonConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Courses");

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Description).HasMaxLength(150);
        builder.Property(e => e.Title).HasMaxLength(150);

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetime())")
            .ValueGeneratedOnAddOrUpdate();

        builder.HasMany(d => d.Materials).WithMany(p => p.Courses)
            .UsingEntity<Dictionary<string, object>>(
                "CourseMaterial",
                r => r.HasOne<Material>().WithMany()
                    .HasForeignKey("MaterialId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseMaterial__Material"),
                l => l.HasOne<Course>().WithMany()
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseMaterial__Course"),
                j =>
                {
                    j.HasKey("CourseId", "MaterialId").HasName("PK__CourseMaterial");
                    j.ToTable("CourseMaterial");
                });
    }
}
