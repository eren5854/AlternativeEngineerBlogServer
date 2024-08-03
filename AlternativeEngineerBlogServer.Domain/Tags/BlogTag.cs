using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Blogs;

namespace AlternativeEngineerBlogServer.Domain.Tags;
public sealed class BlogTag : Entity
{
    public Guid BlogId { get; set; }
    public Blog? Blog { get; set; }
    public Guid TagId { get; set; }
    public Tag? Tag { get; set; }
}
