using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Users;

namespace AlternativeEngineerBlogServer.Domain.Shared;
public sealed class Link : Entity 
{
    public string? LogoName { get; set; }
    public string? Url { get; set; }

    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}
