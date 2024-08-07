using AlternativeEngineerBlogServer.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //builder.HasKey(x => x.Id);
        builder
            .Property(p => p.Name).HasColumnType("varchar(30)").HasMaxLength(30);

        builder.HasQueryFilter(filter => !filter.IsDeleted);

    }
}
