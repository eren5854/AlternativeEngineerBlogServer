using AlternativeEngineerBlogServer.Domain.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
{
    public void Configure(EntityTypeBuilder<BlogTag> builder)
    {
        builder.ToTable("BlogTags");
        builder.HasKey(k => new { k.BlogId, k.TagId });
    }
}
