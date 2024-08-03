using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Blogs;

namespace AlternativeEngineerBlogServer.Domain.Categories;
public sealed class BlogCategory : Entity
{
    public Guid BlogId { get; set; }
    public Blog Blog { get; set; } = default!;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
