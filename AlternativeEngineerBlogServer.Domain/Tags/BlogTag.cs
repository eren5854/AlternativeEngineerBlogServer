using AlternativeEngineerBlogServer.Domain.Blogs;

namespace AlternativeEngineerBlogServer.Domain.Tags;
public sealed class BlogTag
{
    public Guid BlogId { get; set; } = Guid.NewGuid();
    //public Blog? Blog { get; set; }
    public Guid TagId { get; set; } = Guid.NewGuid();
    public Tag? Tag { get; set; }
}
