using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Links.DeleteLinkById;
public sealed record DeleteLinkByIdCommand(Guid Id) : IRequest<Result<string>>;
