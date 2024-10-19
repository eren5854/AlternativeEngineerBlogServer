using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.CreateEmailJsParameter;
public sealed record CreateEmailJsParameterCommand(
    string? Name,
    string? ServiceId,
    string? TemplateId,
    string? PublicKey): IRequest<Result<string>>;
