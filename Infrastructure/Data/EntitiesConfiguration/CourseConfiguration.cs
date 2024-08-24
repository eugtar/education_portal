using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Courses__3214EC078E2A3D18");

        builder.ToTable(tb => tb.HasTrigger("D_U_Courses"));

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Progress).HasColumnType("decimal(5, 2)");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

        builder.HasOne(d => d.Lesson).WithMany(p => p.Courses)
            .HasForeignKey(d => d.LessonId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Courses__LessonI__6383C8BA");

        builder.HasOne(d => d.User).WithMany(p => p.Courses)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Courses__UserId__628FA481");
    }
}
