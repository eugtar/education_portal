using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Users");

        builder.HasIndex(e => e.Email, "UQ__Users").IsUnique();

        builder.Property(e => e.Email).HasMaxLength(50);
        builder.Property(e => e.FirstName).HasMaxLength(50);
        builder.Property(e => e.HashPassword).HasMaxLength(255);
        builder.Property(e => e.LastName).HasMaxLength(50);

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
    }
}
