namespace AlternativeEngineerBlogServer.Domain.DTOs.LinkDtos;
public sealed record UpdateLinkDto(
    Guid Id,
    string? LogoName,
    string Url,
    Guid AppUserId);
