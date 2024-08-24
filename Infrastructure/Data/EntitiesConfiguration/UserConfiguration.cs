using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Users__3214EC07C1BC0D8D");

        builder.ToTable(tb => tb.HasTrigger("D_U_Users"));

        builder.HasIndex(e => e.Email, "UQ__Users__A9D105342144E1D5").IsUnique();

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Email).HasMaxLength(50);
        builder.Property(e => e.FirstName).HasMaxLength(50);
        builder.Property(e => e.HashPassword).HasMaxLength(255);
        builder.Property(e => e.LastName).HasMaxLength(50);
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");
    }
}
