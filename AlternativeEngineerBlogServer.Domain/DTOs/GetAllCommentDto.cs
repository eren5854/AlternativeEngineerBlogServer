namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record GetAllCommentDto(
    Guid Id,
    string Content,
    Guid? BlogId,
    Guid? MainCommentId,
    DateTime? CreatedDate,
    Guid? AppUserId,
    GetCommentUserDto CommentUser);
