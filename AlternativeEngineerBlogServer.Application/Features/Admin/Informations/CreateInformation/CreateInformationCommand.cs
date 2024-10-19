using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.CreateInformation;
public sealed record CreateInformationCommand(
    string Title,
    string SubTitle,
    string Description,
    string? Email,
    string? Address,
    string? PhoneNumber,
    string? LinkedinUrl,
    string? InstagramUrl,
    string? XUrl,
    string? GithubUrl) : IRequest<Result<string>>;
