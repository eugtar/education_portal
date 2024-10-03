using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__UserSkills");

        builder.HasOne(d => d.Skill).WithMany(p => p.UserSkills)
            .HasForeignKey(d => d.SkillId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__UserSkills__SkillId");

        builder.HasOne(d => d.User).WithMany(p => p.UserSkills)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__UserSkills__UserId");
    }
}
