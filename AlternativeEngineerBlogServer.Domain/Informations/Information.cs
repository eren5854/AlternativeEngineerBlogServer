using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Shared;

namespace AlternativeEngineerBlogServer.Domain.Informations;
public sealed class Information : Entity
{
    public Name Title { get; set; } = default!;
    public Name SubTitle { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public string? Address {  get; set; }
    public Link? Link { get; set; }
    public string? PhoneNumber { get; set; }
}
