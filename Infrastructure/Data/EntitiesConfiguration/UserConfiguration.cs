using Domain.Entities.UserGroup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasIndex(e => e.Email, "UQ__Users").IsUnique();

        builder.Property(e => e.Email).HasMaxLength(50);
        builder.Property(e => e.FirstName).HasMaxLength(50);
        builder.Property(e => e.LastName).HasMaxLength(50);

        builder.HasMany(e => e.Claims)
               .WithOne(e => e.User)
               .HasForeignKey(uc => uc.UserId)
               .IsRequired();

        builder.HasMany(e => e.Logins)
            .WithOne(e => e.User)
            .HasForeignKey(ul => ul.UserId)
            .IsRequired();

        builder.HasMany(e => e.Tokens)
            .WithOne(e => e.User)
            .HasForeignKey(ut => ut.UserId)
            .IsRequired();

        builder.HasMany(e => e.UserRoles)
            .WithOne(e => e.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    }
}
