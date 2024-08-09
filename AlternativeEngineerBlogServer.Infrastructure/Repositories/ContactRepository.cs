using AlternativeEngineerBlogServer.Domain.Contacts;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Infrastructure.Context;
using ED.GenericRepository;

namespace AlternativeEngineerBlogServer.Infrastructure.Repositories;
public sealed class ContactRepository : Repository<Contact, ApplicationDbContext>, IContactRepository
{
    public ContactRepository(ApplicationDbContext context) : base(context)
    {
    }
}
