using AlternativeEngineerBlogServer.Domain.Shared;
using AlternativeEngineerBlogServer.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        //builder
        //    .Property(p => p.Gender)
        //    .HasConversion(p => p.Value, 
        //                   v => UserGenderSmartEnum
        //                   .FromValue(v));

        builder
            .Property(p => p.Role)
            .HasConversion(p => p.Value, 
                           v => UserRoleSmartEnum
                           .FromValue(v));

        builder
            .Property(p => p.FirstName)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.LastName)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasColumnType("varchar(75)")
            .HasMaxLength(75)
            .IsRequired();

        builder
            .Property(p => p.About)
            .HasColumnType("varchar(MAX)")
            .HasMaxLength(2000);

        builder
            .Property(p => p.UserName)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.PhoneNumber)
            .HasColumnType("varchar(13)")
            .HasMaxLength(13);

        //builder
        //    .Property(p => p.FirstName)
        //    .HasConversion(name => name.Value,
        //                   v => new Name(v))
        //    .HasColumnType("varchar(50)")
        //    .IsRequired();

        //builder
        //    .Property(p => p.LastName)
        //    .HasConversion(name => name.Value, 
        //                   v => new Name(v))
        //    .HasColumnType("varchar(50)")
        //    .IsRequired();

        builder.HasMany(p => p.Links).WithOne(p => p.AppUser).HasForeignKey(p => p.AppUserId);

        builder
            .HasQueryFilter(filter => !filter.IsDeleted);
    }
}
