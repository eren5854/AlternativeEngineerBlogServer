using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.UpdateComment;
public sealed record UpdateCommentCommand(
    Guid Id,
    Guid AppUserId,
    string Content) : IRequest<Result<string>>;
