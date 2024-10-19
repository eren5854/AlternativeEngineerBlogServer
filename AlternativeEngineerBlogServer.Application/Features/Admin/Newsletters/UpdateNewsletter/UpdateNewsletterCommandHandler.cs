using AlternativeEngineerBlogServer.Domain.Emails;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Newsletters.UpdateNewsletter;
internal sealed class UpdateNewsletterCommandHandler(
    INewsletterRepository newsletterRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateNewsletterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateNewsletterCommand request, CancellationToken cancellationToken)
    {
        Newsletter newsletter = await newsletterRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (newsletter is null)
        {
            return Result<string>.Failure("E-Posta bulunamadı");
        }

        mapper.Map(request, newsletter);
        newsletter.UpdatedDate = DateTime.Now;
        newsletter.UpdatedBy = "Admin";

        newsletterRepository.Update(newsletter);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("E-posta durumu değiştirildi");
    }
}
