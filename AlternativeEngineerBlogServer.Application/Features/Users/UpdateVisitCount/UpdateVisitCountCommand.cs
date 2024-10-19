using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.UpdateVisitCount;
public sealed record UpdateVisitCountCommand(Guid Id) : IRequest<Result<string>>;
