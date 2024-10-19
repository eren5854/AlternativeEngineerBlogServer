using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.UpdateEmailJsParameter;
public sealed record UpdateEmailJsParameterCommand(
    Guid Id,
    string? Name,
    string? ServiceId,
    string? TemplateId,
    string? PublicKey): IRequest<Result<string>>;
