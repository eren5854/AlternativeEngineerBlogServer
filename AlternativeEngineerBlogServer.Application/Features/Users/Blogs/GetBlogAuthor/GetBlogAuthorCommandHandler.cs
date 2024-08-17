using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogAuthor;
internal sealed class GetBlogAuthorCommandHandler(
    IAppUserRepository appUserRepository) : IRequestHandler<GetBlogAuthorCommand, Result<GetBlogAuthorDto>>
{
    public async Task<Result<GetBlogAuthorDto>> Handle(GetBlogAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await appUserRepository
            .Where(p => p.Id == request.Id)
            .Select(s => new GetBlogAuthorDto(
            s.FirstName,
            s.LastName,
            s.Role,
            s.ProfilePicture))
            .FirstOrDefaultAsync(cancellationToken);
        //var author = await appUserRepository.GetByExpressionAsync(p => p.Id == request.Id);
        if (author is null)
        {
            return Result<GetBlogAuthorDto>.Failure("Author not found");
        }

        //var authorResult = new GetAuthorDto(
        //    FirstName: author.FirstName,
        //    LastName: author.LastName,
        //    UserName: author.UserName,
        //    Email: author.Email,
        //    DateOfBirth: author.DateOfBirth,
        //    About: author.About,
        //    Role: author.Role,
        //    PhoneNumber: author.PhoneNumber,
        //    ProfilePicture: author.ProfilePicture);

        return Result<GetBlogAuthorDto>.Succeed(author);
    }
}
