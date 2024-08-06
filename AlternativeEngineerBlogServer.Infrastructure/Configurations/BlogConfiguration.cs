using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        //builder
        //    .Property(p => p.Title)
        //    .HasConversion(name => name.Value, 
        //                   v => new Name(v))
        //    .HasColumnType("varchar(100)")
        //    .IsRequired();

        //builder
        //    .Property(p => p.SubTitle)
        //    .HasConversion(name => name.Value,
        //                   v => new Name(v))
        //    .HasColumnType("varchar(100)")
        //    .IsRequired();

        //builder
        //    .Property(p => p.Content)
        //    .HasColumnType("varchar(max)");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

    }
}
