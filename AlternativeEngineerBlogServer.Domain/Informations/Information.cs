using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Shared;

namespace AlternativeEngineerBlogServer.Domain.Informations;
public sealed class Information : Entity
{
    public string Title { get; set; } = default!;
    public string SubTitle { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public string? Address {  get; set; }
    public string? PhoneNumber { get; set; }
    public string? LinkedinUrl { get; set; }
    public string? InstagramUrl { get; set; }
    public string? XUrl { get; set; }
    public string? GithubUrl { get; set; }

}
