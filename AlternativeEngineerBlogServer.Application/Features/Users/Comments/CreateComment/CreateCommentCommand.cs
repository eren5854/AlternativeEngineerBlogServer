using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.CreateComment;
public sealed record CreateCommentCommand(
    string Content,
    Guid BlogId,
    Guid AppUserId,
    Guid? MainCommentId) : IRequest<Result<string>>;