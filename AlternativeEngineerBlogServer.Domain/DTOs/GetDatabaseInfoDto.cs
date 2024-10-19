namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record GetDatabaseInfoDto(
    string? Name,
    string? DbSize,
    string? Owner,
    string? CreatedDate);
