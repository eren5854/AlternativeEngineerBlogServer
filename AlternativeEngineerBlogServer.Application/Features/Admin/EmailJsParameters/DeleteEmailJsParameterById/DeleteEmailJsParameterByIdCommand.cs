using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.DeleteEmailJsParameterById;
public sealed record DeleteEmailJsParameterByIdCommand(
    Guid Id) : IRequest<Result<string>>;
