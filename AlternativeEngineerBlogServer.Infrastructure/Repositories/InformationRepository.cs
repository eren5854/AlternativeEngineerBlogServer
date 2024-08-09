using AlternativeEngineerBlogServer.Domain.Informations;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Infrastructure.Context;
using ED.GenericRepository;

namespace AlternativeEngineerBlogServer.Infrastructure.Repositories;
public sealed class InformationRepository : Repository<Information, ApplicationDbContext>, IInformationRepository
{
    public InformationRepository(ApplicationDbContext context) : base(context)
    {
    }
}
