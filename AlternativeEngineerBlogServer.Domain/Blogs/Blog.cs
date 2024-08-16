using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Categories;
using AlternativeEngineerBlogServer.Domain.Comments;
using AlternativeEngineerBlogServer.Domain.Shared;
using AlternativeEngineerBlogServer.Domain.Tags;
using AlternativeEngineerBlogServer.Domain.Users;

namespace AlternativeEngineerBlogServer.Domain.Blogs;
public sealed class Blog : Entity
{
    public string Title { get; set; } = string.Empty;
    public string SubTitle { get; set; } = string.Empty;
    public string? MainImage {  get; set; }
    public string Content { get; set; } = string.Empty;
    public int ViewCount { get; set; } = 0;
    public int LikeCount { get; set; } = 0;
    public int CommentCount { get; set; } = 0;

    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; } = default!;


    public ICollection<BlogCategory> BlogCategories { get; set; }
    public ICollection<BlogTag> BlogTags { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
