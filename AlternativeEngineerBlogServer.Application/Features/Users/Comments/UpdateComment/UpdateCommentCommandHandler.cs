using AlternativeEngineerBlogServer.Domain.Comments;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using FluentValidation.Results;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.UpdateComment;
internal sealed class UpdateCommentCommandHandler(
    ICommentRepository commentRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateCommentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        UpdateCommentCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);
        }

        Comment comment = await commentRepository.GetByExpressionAsync(p => p.Id == request.Id && p.AppUserId == request.AppUserId, cancellationToken);
        if (comment is null)
        {
            return Result<string>.Failure("Yorum bulunamadı");
        }

        mapper.Map(request, comment);
        commentRepository.Update(comment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Yorum güncellemesi başarılı");
    }
}
