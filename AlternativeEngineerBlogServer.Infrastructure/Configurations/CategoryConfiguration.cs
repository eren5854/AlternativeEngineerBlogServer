using AlternativeEngineerBlogServer.Domain.Categories;
using AlternativeEngineerBlogServer.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //builder.HasKey(x => x.Id);
        //builder
        //    .Property(p => p.Name)
        //    .HasConversion(name => name.Value, v => new Name(v))
        //    .IsRequired()
        //    .HasColumnType("varchar(50)");
        builder.HasQueryFilter(filter => !filter.IsDeleted);

    }
}
