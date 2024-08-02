using AlternativeEngineerBlogServer.Domain.Abstractions;

namespace AlternativeEngineerBlogServer.Domain.Shared;
public sealed class Link : Entity 
{
    public string? Logo { get; set; }
    public string? Url { get; set; }
}
