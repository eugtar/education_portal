using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class EBookConfiguration : IEntityTypeConfiguration<Ebook>
{
    public void Configure(EntityTypeBuilder<Ebook> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__EBooks__3214EC07AB1317D4");

        builder.ToTable("EBooks", tb => tb.HasTrigger("D_U_EBooks"));

        builder.Property(e => e.Author).HasMaxLength(150);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Format).HasDefaultValue(1);
        builder.Property(e => e.PublishedOn).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Title).HasMaxLength(150);
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

        builder.HasOne(d => d.FormatNavigation).WithMany(p => p.Ebooks)
            .HasForeignKey(d => d.Format)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__EBooks__Format__4AB81AF0");
    }
}
