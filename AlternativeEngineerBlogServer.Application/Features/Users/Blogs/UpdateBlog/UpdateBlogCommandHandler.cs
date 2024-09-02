using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using FluentValidation.Results;
using GenericFileService.Files;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlog;
internal sealed class UpdateBlogCommandHandler(
    IBlogRepository blogRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IAppUserRepository appUserRepository) : IRequestHandler<UpdateBlogCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        UpdateBlogCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);
        }

        AppUser user = await appUserRepository.GetByExpressionAsync(p => p.Id == request.AppUserId);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        Blog blog = await blogRepository.GetByExpressionAsync(p => p.Id == request.Id && p.AppUserId == request.AppUserId);
        if (blog is null)
        {
            return Result<string>.Failure("Blog not found");
        }

        string mainImage = "";
        var response = request.MainImage;
        if (response is null)
        {
            mainImage = blog.MainImage!;
        }
        if(response is not null)
        {
            mainImage = FileService.FileSaveToServer(request.MainImage!, "wwwroot/Images/");
        }


        mapper.Map(request, blog);
        blog.MainImage = mainImage;
        blog.UpdatedDate = DateTime.Now;
        blog.UpdatedBy = user.UserName;

        blogRepository.Update(blog);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Blog update is successful");
    }
}
