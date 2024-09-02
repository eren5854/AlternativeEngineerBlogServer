using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogByAuthorId;
internal sealed class GetBlogByAuthorIdCommandHandler(
    IBlogRepository blogRepository) : IRequestHandler<GetBlogByAuthorIdCommand, Result<List<GetBlogByAuthorDto>>>
{
    public async Task<Result<List<GetBlogByAuthorDto>>> Handle(GetBlogByAuthorIdCommand request, CancellationToken cancellationToken)
    {
        var authorBlogs = await blogRepository
            .Where(p => p.AppUserId == request.Id)
            .Select(b => new GetBlogByAuthorDto(
                b.Id,
                b.Title,
                b.ViewCount,
                b.LikeCount,
                b.CommentCount,
                b.CreatedDate))
            .ToListAsync(cancellationToken);

        if (authorBlogs is null)
        {
            return Result<List<GetBlogByAuthorDto>>.Failure("Blog not found");
        }

        return Result<List<GetBlogByAuthorDto>>.Succeed(authorBlogs);
    }
}
