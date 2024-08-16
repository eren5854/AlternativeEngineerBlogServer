using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.GetUserById;
internal sealed class GetUserByIdCommandHandler(
    IAppUserRepository appUserRepository) : IRequestHandler<GetUserByIdCommand, Result<AppUser>>
{
    public async Task<Result<AppUser>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await appUserRepository.GetByExpressionAsync(p => p.Id ==  request.Id, cancellationToken);
        if (user is null)
        {
            return Result<AppUser>.Failure("User not found");
        }

        return Result<AppUser>.Succeed(user);
    }
}
