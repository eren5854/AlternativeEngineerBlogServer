using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogById;
internal sealed class GetBlogByIdCommandHandler(
    IBlogRepository blogRepository) : IRequestHandler<GetBlogByIdCommand, Result<BlogDto>>
{
    public async Task<Result<BlogDto>> Handle(GetBlogByIdCommand request, CancellationToken cancellationToken)
    {
        var blog = await blogRepository
            .Where(p => p.Id == request.Id)
            .Select(b => new BlogDto(
                b.Id,
                b.Title,
                b.SubTitle,
                b.Content,
                b.MainImage,
                b.ViewCount,
                b.LikeCount,
                b.CommentCount,
                b.CategoryId,
                new GetBlogAuthorDto(
                    b.AppUser.FirstName,
                    b.AppUser.LastName,
                    b.AppUser.Role,
                    b.AppUser.ProfilePicture)))
            .FirstOrDefaultAsync(cancellationToken);

        if (blog is null)
        {
            return Result<BlogDto>.Failure("Blog not found");
        }

        return Result<BlogDto>.Succeed(blog);
    }
}
