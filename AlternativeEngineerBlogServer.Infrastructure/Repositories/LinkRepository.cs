using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Shared;
using AlternativeEngineerBlogServer.Infrastructure.Context;
using ED.GenericRepository;

namespace AlternativeEngineerBlogServer.Infrastructure.Repositories;
internal sealed class LinkRepository : Repository<Link, ApplicationDbContext>, ILinkRepository
{
    public LinkRepository(ApplicationDbContext context) : base(context)
    {
    }
}
