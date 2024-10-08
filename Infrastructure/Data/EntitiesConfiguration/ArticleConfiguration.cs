using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        // builder.HasKey(e => e.Id).HasName("PK__Articles");

        builder.Property(e => e.Link).HasMaxLength(150);
        builder.Property(e => e.Title).HasMaxLength(150);

        // builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        /* builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetime())")
            .ValueGeneratedOnAddOrUpdate(); */
    }
}
