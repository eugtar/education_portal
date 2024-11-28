using Domain.Entities.RoleGroup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

        builder.HasMany(e => e.RoleClaims)
            .WithOne(e => e.Role)
            .HasForeignKey(rc => rc.RoleId)
            .IsRequired();
    }
}
