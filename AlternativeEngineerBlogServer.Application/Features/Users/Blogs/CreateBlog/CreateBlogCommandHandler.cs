using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.CreateBlog;
internal sealed class CreateBlogCommandHandler(
    IBlogRepository blogRepository,
    IUnitOfWork unitOfWork,
    IAppUserRepository appUserRepository,
    IMapper mapper) : IRequestHandler<CreateBlogCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await appUserRepository.GetByExpressionAsync(p => p.Id == request.AppUserId);

        Blog blog = mapper.Map<Blog>(request);
        blog.CreatedBy = user.UserName;
        blog.CreatedDate = DateTime.Now;

        await blogRepository.AddAsync(blog, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Blog create is successful");
    }
}
