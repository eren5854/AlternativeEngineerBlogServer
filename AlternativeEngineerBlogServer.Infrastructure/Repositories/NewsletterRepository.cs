using AlternativeEngineerBlogServer.Domain.Emails;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Infrastructure.Context;
using ED.GenericRepository;

namespace AlternativeEngineerBlogServer.Infrastructure.Repositories;
internal sealed class NewsletterRepository : Repository<Newsletter, ApplicationDbContext>, INewsletterRepository
{
    public NewsletterRepository(ApplicationDbContext context) : base(context)
    {
    }
}
