using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.UpdateInformation;
public sealed record UpdateInformationCommand(
    Guid Id,
    string Title,
    string SubTitle,
    string Description,
    string? Address,
    string? PhoneNumber,
    string? LinkedinUrl,
    string? InstagramUrl,
    string? XUrl,
    string? GithubUrl) : IRequest<Result<string>>;
