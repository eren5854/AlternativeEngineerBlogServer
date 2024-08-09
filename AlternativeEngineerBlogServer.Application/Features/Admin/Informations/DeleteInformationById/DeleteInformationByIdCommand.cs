using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.DeleteInformationById;
public sealed record DeleteInformationByIdCommand(
    Guid Id) : IRequest<Result<string>>;
