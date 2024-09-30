using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Videos__3214EC076F6F5848");

        builder.ToTable(tb => tb.HasTrigger("D_U_Videos"));

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Quality).HasDefaultValue(1);
        builder.Property(e => e.Title).HasMaxLength(150);
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

        builder.HasOne(d => d.QualityNavigation).WithMany(p => p.Videos)
            .HasForeignKey(d => d.Quality)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Videos__UpdatedA__4316F928");
    }
}
