using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlogViewCount;
internal sealed class UpdateBlogViewCountCommandHandler(
    IBlogRepository blogRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateBlogViewCountCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateBlogViewCountCommand request, CancellationToken cancellationToken)
    {
        Blog blog = await blogRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (blog is null)
        {
            return Result<string>.Failure("Blog bulunamadı");
        }

        blog.ViewCount++;
        blogRepository.Update(blog);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Görüntülenme sayısı güncellendi");
    }
}
