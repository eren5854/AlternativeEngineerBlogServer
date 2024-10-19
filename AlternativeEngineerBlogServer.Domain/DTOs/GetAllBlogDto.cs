namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record GetAllBlogDto(
    Guid? Id,
    string Title,
    string? SubTitle,
    string? MainImage,
    int? ViewCount,
    Guid CategoryId,
    DateTime? CreatedDate,
    GetBlogAuthorDto? Author,
    GetCategoryDto Category);
