using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlogLikeCount;
public sealed record UpdateBlogLikeCountCommand(
    Guid Id) : IRequest<Result<string>>;
