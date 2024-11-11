using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Courses");

        builder.Property(e => e.Description).HasMaxLength(150);
        builder.Property(e => e.Title).HasMaxLength(150);

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

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
                    j.HasData(
                        new { CourseId = 1, MaterialId = 1 },
                        new { CourseId = 2, MaterialId = 2 },
                        new { CourseId = 3, MaterialId = 3 },
                        new { CourseId = 4, MaterialId = 4 },
                        new { CourseId = 5, MaterialId = 5 },
                        new { CourseId = 6, MaterialId = 6 },
                        new { CourseId = 7, MaterialId = 7 },
                        new { CourseId = 8, MaterialId = 8 },
                        new { CourseId = 9, MaterialId = 9 },
                        new { CourseId = 1, MaterialId = 10 },
                        new { CourseId = 2, MaterialId = 11 },
                        new { CourseId = 3, MaterialId = 12 },
                        new { CourseId = 4, MaterialId = 13 },
                        new { CourseId = 5, MaterialId = 14 },
                        new { CourseId = 6, MaterialId = 15 },
                        new { CourseId = 7, MaterialId = 16 },
                        new { CourseId = 8, MaterialId = 17 },
                        new { CourseId = 9, MaterialId = 18 },
                        new { CourseId = 1, MaterialId = 19 },
                        new { CourseId = 2, MaterialId = 20 },
                        new { CourseId = 3, MaterialId = 21 },
                        new { CourseId = 4, MaterialId = 22 },
                        new { CourseId = 5, MaterialId = 23 },
                        new { CourseId = 6, MaterialId = 24 },
                        new { CourseId = 7, MaterialId = 25 },
                        new { CourseId = 8, MaterialId = 26 },
                        new { CourseId = 9, MaterialId = 27 }
                    );
                });

        builder.HasMany(d => d.Skills).WithMany(p => p.Courses)
            .UsingEntity<Dictionary<string, object>>(
                "CourseSkill",
                r => r.HasOne<Skill>().WithMany()
                    .HasForeignKey("SkillId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseSkill__Skill"),
                l => l.HasOne<Course>().WithMany()
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseSkill__Course"),
                j =>
                {
                    j.HasKey("CourseId", "SkillId").HasName("PK__CourseSkill");
                    j.ToTable("CourseSkill");
                    j.HasData(
                        new{CourseId = 1, SkillId = 1},
                        new{CourseId = 2, SkillId = 1},
                        new{CourseId = 2, SkillId = 2},
                        new{CourseId = 3, SkillId = 1},
                        new{CourseId = 3, SkillId = 2},
                        new{CourseId = 3, SkillId = 3},
                        new{CourseId = 4, SkillId = 4},
                        new{CourseId = 5, SkillId = 4},
                        new{CourseId = 5, SkillId = 5},
                        new{CourseId = 6, SkillId = 4},
                        new{CourseId = 6, SkillId = 5},
                        new{CourseId = 6, SkillId = 6},
                        new{CourseId = 7, SkillId = 7},
                        new{CourseId = 8, SkillId = 7},
                        new{CourseId = 8, SkillId = 8},
                        new{CourseId = 9, SkillId = 7},
                        new{CourseId = 9, SkillId = 8},
                        new{CourseId = 9, SkillId = 9}
                    );
                });
    }
}
