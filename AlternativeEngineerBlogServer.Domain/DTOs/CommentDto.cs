namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record CommentDto(
    Guid? Id,
    string Content,
    Guid? MainCommentId,
    DateTime? CreatedDate,
    GetCommentUserDto CommentUser);
