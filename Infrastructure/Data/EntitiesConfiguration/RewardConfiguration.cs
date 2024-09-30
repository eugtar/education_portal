using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class RewardConfiguration : IEntityTypeConfiguration<Reward>
{
    public void Configure(EntityTypeBuilder<Reward> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Rewards__3214EC072569389F");

        builder.ToTable(tb => tb.HasTrigger("D_U_Rewards"));

        builder.HasIndex(e => e.Name, "UQ__Rewards__737584F69D207591").IsUnique();

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Name).HasMaxLength(50);
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");
    }
}
