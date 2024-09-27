using System.Runtime.Serialization.Formatters;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class FormatConfiguration : IEntityTypeConfiguration<Format>
{
    public void Configure(EntityTypeBuilder<Format> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Formats");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.FormatType).HasMaxLength(10);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetime())")
            .ValueGeneratedOnAddOrUpdate();
    }
}
