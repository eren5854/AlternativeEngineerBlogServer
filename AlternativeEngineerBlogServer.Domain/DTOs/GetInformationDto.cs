namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record GetInformationDto(
    string Title,
    string SubTitle,
    string Description,
    string? Address,
    string? PhoneNumber,
    string? LinkedinUrl,
    string? InstagramUrl,
    string? XUrl,
    string? GithubUrl);
