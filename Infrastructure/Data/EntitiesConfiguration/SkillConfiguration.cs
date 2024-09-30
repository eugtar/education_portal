using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class RewardConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Skills");

        builder.HasIndex(e => e.Name, "UQ__Skills").IsUnique();

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Name).HasMaxLength(50);

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetime())")
            .ValueGeneratedOnAddOrUpdate();
    }
}
