using AlternativeEngineerBlogServer.Domain.Informations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class InformationConfiguration : IEntityTypeConfiguration<Information>
{
    public void Configure(EntityTypeBuilder<Information> builder)
    {
        builder
            .ToTable("Informations");

        builder
            .Property(p => p.Title)
            .IsRequired()
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder
            .Property(p => p.SubTitle)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder
            .Property(p => p.Description)
            .IsRequired()
            .HasColumnType("varchar(300)")
            .HasMaxLength(300);

        builder
            .Property(p => p.Address)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder
            .Property(p => p.PhoneNumber)
            .HasColumnType("varchar(11)")
            .HasMaxLength(11);

        builder
            .Property(p => p.LinkedinUrl)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder
            .Property(p => p.InstagramUrl)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder
            .Property(p => p.XUrl)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder
            .Property(p => p.GithubUrl)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
