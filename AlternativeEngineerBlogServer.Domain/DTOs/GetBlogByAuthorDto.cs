namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record GetBlogByAuthorDto(
    Guid? Id,
    string Title,
    int ViewCount,
    int LikeCount,
    int CommentCount,
    DateTime? CreatedDate);
