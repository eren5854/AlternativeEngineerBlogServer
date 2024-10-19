using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlogLikeCount;
internal sealed class UpdateBlogLikeCountCommandHandler(
    IBlogRepository blogRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateBlogLikeCountCommand, Result<string>>

{
    public async Task<Result<string>> Handle(UpdateBlogLikeCountCommand request, CancellationToken cancellationToken)
    {
        Blog blog = await blogRepository.GetByExpressionAsync(p => p.Id == request.Id);
        if (blog is null)
        {
            return Result<string>.Failure("Blog bulunamadı");
        }

        blog.LikeCount++;
        blogRepository.Update(blog);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Blog beğenme güncellendi");
    }
}
