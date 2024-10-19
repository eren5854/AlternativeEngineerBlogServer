using AlternativeEngineerBlogServer.Domain.Emails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class NewsletterConfiguration : IEntityTypeConfiguration<Newsletter>
{
    public void Configure(EntityTypeBuilder<Newsletter> builder)
    {
        builder
            .Property(p => p.Email)
            .IsRequired()
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
