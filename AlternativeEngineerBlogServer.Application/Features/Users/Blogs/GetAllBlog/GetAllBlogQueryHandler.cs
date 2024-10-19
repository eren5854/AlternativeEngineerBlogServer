using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetAllBlog;
internal sealed class GetAllBlogQueryHandler(
    IBlogRepository blogRepository) : IRequestHandler<GetAllBlogQuery, Result<List<GetAllBlogDto>>>
{
    public async Task<Result<List<GetAllBlogDto>>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
    {

        //var blogs = await blogRepository
        //    .GetAll()
        //    .Include(b => b.AppUser)
        //    .OrderBy(o => o.CreatedDate)
        //    .ToListAsync(cancellationToken);

        var blogs = await blogRepository
            .GetAll()
            .OrderBy(o => o.CreatedDate)
            .Select(b => new GetAllBlogDto(
                b.Id,
                b.Title,
                b.SubTitle,
                b.MainImage,
                b.ViewCount,
                b.CategoryId,
                b.CreatedDate,
                new GetBlogAuthorDto(
                    b.AppUser.FirstName,
                    b.AppUser.LastName,
                    b.AppUser.UserName,
                    b.AppUser.Role,
                    b.AppUser.ProfilePicture),
                new GetCategoryDto(
                    b.Category.Id,
                    b.Category.Name)))
            .ToListAsync(cancellationToken);

        var sortedBlogs = blogs.OrderByDescending(o => o.CreatedDate).ToList();

        return Result<List<GetAllBlogDto>>.Succeed(sortedBlogs);
    }
}
