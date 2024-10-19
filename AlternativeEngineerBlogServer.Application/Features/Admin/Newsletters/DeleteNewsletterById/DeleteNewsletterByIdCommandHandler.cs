using AlternativeEngineerBlogServer.Domain.Emails;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Newsletters.DeleteNewsletter;
internal sealed class DeleteNewsletterByIdCommandHandler(
    INewsletterRepository newsletterRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteNewsletterByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteNewsletterByIdCommand request, CancellationToken cancellationToken)
    {
        Newsletter newsletter = await newsletterRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (newsletter is null)
        {
            return Result<string>.Failure("E-posta adresi bulunamadı");
        }

        newsletter.IsDeleted = true;
        newsletterRepository.Update(newsletter);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("E- posta adresi silme işlemi başarılı");
    }
}
