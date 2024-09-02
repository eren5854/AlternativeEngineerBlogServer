using AlternativeEngineerBlogServer.Domain.Categories;

namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record BlogDto(
    Guid? Id,
    string Title,
    string? SubTitle,
    string? Content,
    string? MainImage,
    int ViewCount,
    int LikeCount,
    int CommentCount,
    Guid CategoryId,
    DateTime? CreatedDate,
    GetBlogAuthorDto? Author,
    GetCategoryDto Category);
