using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class QualityConfiguration : IEntityTypeConfiguration<Quality>
{
    public void Configure(EntityTypeBuilder<Quality> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Qualitie__3214EC072A1AE5CC");

        builder.ToTable(tb => tb.HasTrigger("D_U_Qualities"));

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Quality1)
            .HasMaxLength(10)
            .HasColumnName("Quality");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");
    }
}
