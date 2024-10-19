using AlternativeEngineerBlogServer.Domain.Abstractions;

namespace AlternativeEngineerBlogServer.Domain.EmailJsParameters;
public sealed class EmailJsParameter: Entity
{
    public string? Name { get; set; }
    public string? ServiceId { get; set; }
    public string? TemplateId { get; set; }
    public string? PublicKey { get; set; }
}
