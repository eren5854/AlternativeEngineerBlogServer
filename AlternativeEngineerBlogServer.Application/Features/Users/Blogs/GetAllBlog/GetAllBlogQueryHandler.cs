using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetAllBlog;
internal sealed class GetAllBlogQueryHandler(
    IBlogRepository blogRepository,
    IAppUserRepository appUserRepository) : IRequestHandler<GetAllBlogQuery, Result<List<BlogDto>>>
{
    public async Task<Result<List<BlogDto>>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
    {

        //var blogs = await blogRepository
        //    .GetAll()
        //    .Include(b => b.AppUser)
        //    .OrderBy(o => o.CreatedDate)
        //    .ToListAsync(cancellationToken);

        var blogs = await blogRepository
            .GetAll()
            .OrderBy(o => o.CreatedDate)
            .Select(b => new BlogDto(
                b.Title,
                b.SubTitle,
                b.Content,
                b.MainImage, // Opsiyonel, eğer null olabiliyorsa sorun olmaz
                b.ViewCount,
                b.LikeCount,
                b.CommentCount,
                new GetBlogAuthorDto(
                    b.AppUser.FirstName,
                    b.AppUser.LastName,
                    b.AppUser.Role,
                    b.AppUser.ProfilePicture))
            )
            .ToListAsync(cancellationToken);


        return Result<List<BlogDto>>.Succeed(blogs);
    }
}
