using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Users.DeleteUserById;
internal sealed class DeleteUserByIdCommandHandler(
    IAppUserRepository appUserRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await appUserRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (user is null)
        {
            return Result<string>.Failure("user not found");
        }

        user.IsDeleted = true;
        appUserRepository.Update(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Delete is successful");
    }
}
