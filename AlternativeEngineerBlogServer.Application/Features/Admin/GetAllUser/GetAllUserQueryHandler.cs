using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.GetAllUser;
internal sealed class GetAllUserQueryHandler(
    IAppUserRepository appUserRepository) : IRequestHandler<GetAllUserQuery, Result<List<AppUser>>>
{
    public async Task<Result<List<AppUser>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var user = await appUserRepository
            .GetAll()
            .OrderByDescending(p => p.CreatedDate)
            .ToListAsync(cancellationToken);

        return Result<List<AppUser>>.Succeed(user);
    }
}
