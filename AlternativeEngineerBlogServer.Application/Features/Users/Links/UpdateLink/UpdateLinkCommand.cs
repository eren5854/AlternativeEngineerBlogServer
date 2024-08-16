using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Links.UpdateLink;
public sealed record UpdateLinkCommand(
    Guid Id,
    string LogoName,
    string Url,
    Guid AppUserId) : IRequest<Result<string>>;
