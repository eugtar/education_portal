using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Skills__3214EC07BBF87B0B");

        builder.ToTable(tb => tb.HasTrigger("D_U_Skills"));

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

        builder.HasOne(d => d.Reward).WithMany(p => p.Skills)
            .HasForeignKey(d => d.RewardId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Skills__RewardId__6A30C649");

        builder.HasOne(d => d.User).WithMany(p => p.Skills)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Skills__UserId__693CA210");
    }
}
