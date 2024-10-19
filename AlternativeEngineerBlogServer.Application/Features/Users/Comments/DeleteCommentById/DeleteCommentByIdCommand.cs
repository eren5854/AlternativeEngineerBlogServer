using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.DeleteCommentById;
public sealed record DeleteCommentByIdCommand(
    Guid Id,
    Guid AppUserId,
    Guid BlogId) : IRequest<Result<string>>;
