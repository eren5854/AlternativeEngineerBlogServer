namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record BlogDto(
    string Title,
    string SubTitle,
    string Content,
    string? MainImage,
    int ViewCount,
    int LikeCount,
    int CommentCount,
    GetBlogAuthorDto Author);
