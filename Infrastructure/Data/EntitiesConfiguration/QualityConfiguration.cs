using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class QualityConfiguration : IEntityTypeConfiguration<Quality>
{
    public void Configure(EntityTypeBuilder<Quality> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Qualities");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.QualityType).HasMaxLength(10);

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
    }
}
