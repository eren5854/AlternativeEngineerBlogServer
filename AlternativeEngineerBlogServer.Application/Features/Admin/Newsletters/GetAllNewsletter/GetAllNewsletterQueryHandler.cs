using AlternativeEngineerBlogServer.Domain.Emails;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Newsletters.GetAllNewsletter;
internal sealed class GetAllNewsletterQueryHandler(
    INewsletterRepository newsletterRepository) : IRequestHandler<GetAllNewsletterQuery, Result<List<Newsletter>>>
{
    public async Task<Result<List<Newsletter>>> Handle(GetAllNewsletterQuery request, CancellationToken cancellationToken)
    {
        var newsletters = await newsletterRepository.GetAll().ToListAsync(cancellationToken);
        return Result<List<Newsletter>>.Succeed(newsletters);
    }
}
