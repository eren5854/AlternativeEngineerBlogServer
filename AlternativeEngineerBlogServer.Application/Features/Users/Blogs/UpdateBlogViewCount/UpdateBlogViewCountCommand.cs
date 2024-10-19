using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlogViewCount;
public sealed record UpdateBlogViewCountCommand(
    Guid Id) : IRequest<Result<string>>;
