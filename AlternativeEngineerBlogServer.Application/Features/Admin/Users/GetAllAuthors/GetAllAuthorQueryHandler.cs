using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Users.GetAllAuthors;
internal sealed class GetAllAuthorQueryHandler(
    IAppUserRepository appUserRepository) : IRequestHandler<GetAllAuthorQuery, Result<List<AppUser>>>
{
    public async Task<Result<List<AppUser>>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
    {
        var authors = await appUserRepository
            .GetAll()
            .Where(p => p.Role == 2)
            .OrderByDescending(p => p.CreatedDate)
            .ToListAsync(cancellationToken);

        return Result<List<AppUser>>.Succeed(authors);
    }
}
