using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Comments;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using FluentValidation.Results;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.CreateComment;
internal sealed class CreateCommentCommandHandler(
    ICommentRepository commentRepository,
    IAppUserRepository appUserRepository,
    IBlogRepository blogRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateCommentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        CreateCommentCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);
        }

        AppUser appUser = await appUserRepository.GetByExpressionAsync(p => p.Id == request.AppUserId);
        if (appUser is null)
        {
            return Result<string>.Failure("Kullanıcı bulunamadı");
        }

        Blog blog = await blogRepository.GetByExpressionAsync(p => p.Id == request.BlogId);
        if (blog is null)
        {
            return Result<string>.Failure("Blog bulunamadı");
        }

        if(request.MainCommentId != null)
        {
            Comment comment1 = await commentRepository.GetByExpressionAsync(p => p.Id == request.MainCommentId);
            if (comment1 is null)
            {
                return Result<string>.Failure("Ana yorum bulunamadı");
            }
        }

        Comment comment = mapper.Map<Comment>(request);
        comment.CreatedBy = appUser.UserName!;
        comment.CreatedDate = DateTime.Now;

        blog.CommentCount++;
        blogRepository.Update(blog);

        await commentRepository.AddAsync(comment,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result<string>.Succeed("Yorum başarılıyla kaydedildi");
    }
}
