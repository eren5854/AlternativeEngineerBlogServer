using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Shared;

namespace AlternativeEngineerBlogServer.Domain.Contacts;
public sealed class Contact : Entity
{
    public string ContactName { get; set; } = default!;
    public string ContactEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
