using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.GetAllAuthors;
internal sealed class GetAllAuthorQueryHandler(
    IAppUserRepository appUserRepository) : IRequestHandler<GetAllAuthorQuery, Result<List<GetAuthorDto>>>
{
    public async Task<Result<List<GetAuthorDto>>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
    {
        var authors = await appUserRepository
            .GetAll()
            .Where(p => p.Role == 2)
            .OrderBy(o => o.FirstName)
            .Select(s => new GetAuthorDto(
                s.FirstName, 
                s.LastName,
                s.UserName,
                s.Email,
                s.DateOfBirth,
                s.About,
                s.Role,
                s.PhoneNumber,
                s.ProfilePicture
            ))
            .ToListAsync(cancellationToken);
        return Result<List<GetAuthorDto>>.Succeed(authors);
    }
}
