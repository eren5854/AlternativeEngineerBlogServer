using AlternativeEngineerBlogServer.Domain.Blogs;

namespace AlternativeEngineerBlogServer.Domain.Categories;
public sealed class BlogCategory
{
    public Guid BlogId { get; set; } = Guid.NewGuid();
    //public Blog Blog { get; set; } = default!;
    public Guid CategoryId { get; set; } = Guid.NewGuid();
    public Category Category { get; set; } = default!;
}
