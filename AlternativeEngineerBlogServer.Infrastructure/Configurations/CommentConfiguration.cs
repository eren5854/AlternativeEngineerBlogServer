using AlternativeEngineerBlogServer.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .Property(p => p.Content)
            .IsRequired()
            .HasColumnType("varchar(1000)")
            .HasMaxLength(500);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
