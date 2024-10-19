using AlternativeEngineerBlogServer.Domain.EmailJsParameters;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Infrastructure.Context;
using ED.GenericRepository;

namespace AlternativeEngineerBlogServer.Infrastructure.Repositories;
public sealed class EmailJsParameterRepository : Repository<EmailJsParameter, ApplicationDbContext>, IEmailJsParameterRepository
{
    public EmailJsParameterRepository(ApplicationDbContext context) : base(context)
    {
    }
}
