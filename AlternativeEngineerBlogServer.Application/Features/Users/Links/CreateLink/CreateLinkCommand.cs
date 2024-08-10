using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Links.CreateLink;
public sealed record CreateLinkCommand(
    string LogoName,
    string Url,
    Guid AppUserId) : IRequest<Result<string>>;
