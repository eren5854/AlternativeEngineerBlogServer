using AlternativeEngineerBlogServer.Domain.Contacts;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Contacts.GetAllContact;
internal sealed class GetAllContactQueryHandler(
    IContactRepository contactRepository) : IRequestHandler<GetAllContactQuery, Result<List<Contact>>>
{
    public async Task<Result<List<Contact>>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
    {
        var contacts = await contactRepository
            .GetAll()
            .OrderBy(o => o.CreatedDate)
            .ToListAsync(cancellationToken);
        return Result<List<Contact>>.Succeed(contacts);
    }
}
