using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using AlternativeEngineerBlogServer.Infrastructure.Context;
using ED.GenericRepository;

namespace AlternativeEngineerBlogServer.Infrastructure.Repositories;
public sealed class AppUserRepository : Repository<AppUser, ApplicationDbContext>, IAppUserRepositry
{
    public AppUserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
