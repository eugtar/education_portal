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

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetime())")
            .ValueGeneratedOnAddOrUpdate();

        builder.HasData(
            new { Id = 1, QualityType = "144p" },
            new { Id = 2, QualityType = "240p" },
            new { Id = 3, QualityType = "360p" },
            new { Id = 4, QualityType = "480p" },
            new { Id = 5, QualityType = "720p" },
            new { Id = 6, QualityType = "1080p" },
            new { Id = 7, QualityType = "1440p" },
            new { Id = 8, QualityType = "2160p" }
        );
    }
}
