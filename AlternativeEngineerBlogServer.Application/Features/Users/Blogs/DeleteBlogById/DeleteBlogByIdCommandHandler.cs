using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.DeleteBlogById;
internal sealed class DeleteBlogByIdCommandHandler(
    IBlogRepository blogRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteBlogByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteBlogByIdCommand request, CancellationToken cancellationToken)
    {
        Blog blog = await blogRepository
            .GetByExpressionAsync(p => p.Id == request.Id && 
            p.AppUserId == request.AppUserId);
        if (blog is null)
        {
            return Result<string>.Failure("Blog not found");
        }

        blog.IsDeleted = true;
        blogRepository.Update(blog);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Blog delete is successful");
    }
}
