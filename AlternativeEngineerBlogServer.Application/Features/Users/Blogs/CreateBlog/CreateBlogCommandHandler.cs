using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using GenericFileService.Files;
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

        string mainImage = "";
        var response = request.MainImage;
        if (response is null)
        {
            mainImage = "";
        }
        else
        {
            mainImage = FileService.FileSaveToServer(request.MainImage!, "wwwroot/Images/");
        }

        Blog blog = mapper.Map<Blog>(request);
        blog.MainImage = mainImage;
        blog.CreatedBy = user.FullName;
        blog.CreatedDate = DateTime.Now;

        await blogRepository.AddAsync(blog, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Blog create is successful");
    }
}
