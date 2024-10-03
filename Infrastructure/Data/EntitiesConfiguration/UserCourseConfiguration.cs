using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
{
    public void Configure(EntityTypeBuilder<UserCourse> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__UserCourses");

        builder.Property(e => e.Progress).HasColumnType("decimal(5, 2)");

        builder.HasOne(d => d.Course).WithMany(p => p.UserCourses)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__UserCourses__CourseId");

        builder.HasOne(d => d.User).WithMany(p => p.UserCourses)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__UserCourses__UserId");
    }
}
