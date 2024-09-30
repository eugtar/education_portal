using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class EBookConfiguration : IEntityTypeConfiguration<Ebook>
{
    public void Configure(EntityTypeBuilder<Ebook> builder)
    {
        // builder.HasKey(e => e.Id).HasName("PK__EBooks");

        builder.Property(e => e.Author).HasMaxLength(150);
        builder.Property(e => e.FormatId).HasDefaultValue(1);
        builder.Property(e => e.PublishedOn).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Title).HasMaxLength(150);

        // builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        /* builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetime())")
            .ValueGeneratedOnAddOrUpdate(); */

        builder.HasOne(d => d.Format).WithMany(p => p.Ebooks)
            .HasForeignKey(d => d.FormatId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__EBooks__FormatId");
    }
}
