using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.DeleteBlogById;
public sealed record DeleteBlogByIdCommand(
    Guid Id,
    Guid AppUserId) : IRequest<Result<string>>;
