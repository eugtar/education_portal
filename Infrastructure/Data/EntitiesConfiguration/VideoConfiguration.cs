using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        // builder.HasKey(e => e.Id).HasName("PK__Videos");

        builder.Property(e => e.QualityId).HasDefaultValue(1);
        builder.Property(e => e.Title).HasMaxLength(150);

        // builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        /* builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetime())")
            .ValueGeneratedOnAddOrUpdate(); */

        builder.HasOne(d => d.Quality).WithMany(p => p.Videos)
            .HasForeignKey(d => d.QualityId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Videos__QualityId");
    }
}
