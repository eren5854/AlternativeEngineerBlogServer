using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.ConfirmEmail;
internal sealed class ConfirmEmailCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<ConfirmEmailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        user.EmailConfirmed = true;
        await userManager.UpdateAsync(user);

        return Result<string>.Succeed("Email address confirmed successfully");
    }
}
