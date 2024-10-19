using AlternativeEngineerBlogServer.Domain.Emails;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Newsletters.CreateNewsletter;
internal sealed class CreateNewsletterCommandHandler(
    INewsletterRepository newsletterRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateNewsletterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateNewsletterCommand request, CancellationToken cancellationToken)
    {
        var isNewsletterExists = await newsletterRepository.AnyAsync(p => p.Email ==  request.Email);
        if (isNewsletterExists)
        {
            return Result<string>.Failure("Email adresi zaten bültene kayıtlı");
        }

        Newsletter newsletter =  mapper.Map<Newsletter>(request);
        newsletter.IsActive = true;
        newsletter.CreatedDate = DateTime.Now;
        newsletter.CreatedBy = request.Email;

        await newsletterRepository.AddAsync(newsletter, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Email adresi e-bültene kaydedildi.");
    }
}
