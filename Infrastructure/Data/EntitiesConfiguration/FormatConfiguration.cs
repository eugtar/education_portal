using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class FormatConfiguration : IEntityTypeConfiguration<Format>
{
    public void Configure(EntityTypeBuilder<Format> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Formats__3214EC070CEC5852");

        builder.ToTable(tb => tb.HasTrigger("D_U_Formats"));

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Format1)
            .HasMaxLength(10)
            .HasColumnName("Format");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");
    }
}
