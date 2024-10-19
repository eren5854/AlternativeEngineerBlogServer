using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Comments;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.DeleteCommentById.DeleteCommentById;
internal sealed class DeleteCommentByIdCommandHandler(
    ICommentRepository commentRepository,
    IAppUserRepository appUserRepository,
    IBlogRepository blogRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCommentByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
    {
        AppUser appUser = await appUserRepository.GetByExpressionAsync(p => p.Id == request.AppUserId, cancellationToken);
        if (appUser is null)
        {
            return Result<string>.Failure("Yorum sahibi bulunamadı");
        }

        Comment comment = await commentRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (comment is null)
        {
            return Result<string>.Failure("Yorum bulunamadı");
        }

        if (comment.MainComment is null)
        {
            var mainComments = await commentRepository.GetAll().Where(p => p.MainCommentId == request.Id).ToListAsync(cancellationToken);
            if (mainComments is null)
            {
                return Result<string>.Failure("Alt yorumlar bulunamadı");
            }
            foreach (var mainComment in mainComments)
            {
                mainComment.IsDeleted = true;
                commentRepository.Update(mainComment);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }

        Blog blog = await blogRepository.GetByExpressionAsync(p => p.Id == request.BlogId, cancellationToken);
        if (blog is null)
        {
            return Result<string>.Failure("Blog bulunamadı");
        }

        comment.IsDeleted = true;
        commentRepository.Update(comment);

        blog.CommentCount--;
        if (blog.CommentCount < 0)
        {
            blog.CommentCount = 0;
        }
        blogRepository.Update(blog);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Yorum silme işlemi başarılı");
    }
}
