using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Users;

namespace AlternativeEngineerBlogServer.Domain.Comments;
public sealed class Comment : Entity
{
    public string Content { get; set; } = string.Empty;
    public Guid? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public Guid? BlogId { get; set; }
    public Blog? Blog { get; set; }
}
