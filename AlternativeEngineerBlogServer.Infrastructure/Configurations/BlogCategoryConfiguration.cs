using AlternativeEngineerBlogServer.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
{
    public void Configure(EntityTypeBuilder<BlogCategory> builder)
    {
        builder.ToTable("BlogCategories");
        builder.HasKey(k => new {k.BlogId, k.CategoryId});
    }
}
