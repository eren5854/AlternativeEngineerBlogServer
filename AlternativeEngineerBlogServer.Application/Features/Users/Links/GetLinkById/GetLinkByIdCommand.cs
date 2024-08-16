using AlternativeEngineerBlogServer.Domain.Shared;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Links.GetLinkById;
public sealed record GetLinkByIdCommand(Guid Id) : IRequest<Result<List<Link>>>;
