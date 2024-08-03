using AlternativeEngineerBlogServer.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(p => p.Gender).HasConversion(p => p.Value, v => UserGenderSmartEnum.FromValue(v));
        builder.Property(p => p.Role).HasConversion(p => p.Value, v => UserRoleSmartEnum.FromValue(v));

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
