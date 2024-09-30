using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Materials");

        builder.UseTphMappingStrategy();
        builder.HasDiscriminator<string>(e => e.Type);
        builder.Property(e => e.Type).HasMaxLength(50).HasColumnName("Type");
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetime())")
            .ValueGeneratedOnAddOrUpdate();
    }
}
