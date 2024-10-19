using AlternativeEngineerBlogServer.Domain.Abstractions;

namespace AlternativeEngineerBlogServer.Domain.Emails;
public sealed class Newsletter : Entity
{
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
