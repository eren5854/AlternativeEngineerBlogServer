using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlog;
public sealed record UpdateBlogCommand(
    Guid Id,
    string Title,
    string SubTitle,
    IFormFile? MainImage,
    string Content,
    Guid AppUserId,
    Guid CategoryId) : IRequest<Result<string>>;
