using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.ChangePassword;
internal sealed class ChangePasswordCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<ChangePasswordCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        ChangePasswordCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException(string.Join(", ", validationResult.Errors));
        }

        AppUser? user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        if (request.NewPassword == request.CurrentPassword)
        {
            return Result<string>.Failure("Yeni şifre eskisi ile aynı olamaz");
        }

        IdentityResult result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Old password is wrong");
        }

        return Result<string>.Succeed("Password change is successful");
    }
}
