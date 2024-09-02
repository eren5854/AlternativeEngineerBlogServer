using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogById;
internal sealed class GetBlogByIdCommandHandler(
    IBlogRepository blogRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<GetBlogByIdCommand, Result<BlogDto>>
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
                b.CreatedDate,
                new GetBlogAuthorDto(
                    b.AppUser.FirstName,
                    b.AppUser.LastName,
                    b.AppUser.Role,
                    b.AppUser.ProfilePicture),
                 new GetCategoryDto(
                    b.Category.Id,
                    b.Category.Name)))
            .FirstOrDefaultAsync(cancellationToken);

        Blog blog1 = await blogRepository.GetByExpressionAsync(p => p.Id == request.Id);
        blog1.ViewCount += 1;
        blogRepository.Update(blog1);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        if (blog is null)
        {
            return Result<BlogDto>.Failure("Blog not found");
        }

        return Result<BlogDto>.Succeed(blog);
    }
}
