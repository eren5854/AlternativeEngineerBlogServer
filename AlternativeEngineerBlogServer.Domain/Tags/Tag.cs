using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Shared;

namespace AlternativeEngineerBlogServer.Domain.Tags;
public sealed class Tag : Entity
{
    public string Name { get; set; } = string.Empty;
    //public string Description { get; set; } = string.Empty;
}
