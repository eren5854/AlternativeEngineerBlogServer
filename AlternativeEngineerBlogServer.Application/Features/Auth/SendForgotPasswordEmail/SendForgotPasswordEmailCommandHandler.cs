using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using GenericEmailService;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.SendForgotPasswordEmail;
internal sealed class SendForgotPasswordEmailCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<SendForgotPasswordEmailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(SendForgotPasswordEmailCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        string body = CreateBody(user);
        string subject = "ForgotPassword";

        EmailConfigurations emailConfigurations = new(
           "smtp-mail.outlook.com",
           "ypfppzbkknupvsvc",
           587,
           false,
           true);

        EmailModel<Stream> emailModel = new(
            emailConfigurations,
            "erendelibas58@outlook.com",
            new List<string> { user.Email ?? "" },
            subject,
            body,
            null);

        await EmailService.SendEmailWithMailKitAsync(emailModel);

        return Result<string>.Succeed("New password email has been sent");
    }

    private string CreateBody(AppUser user)
    {
        string body = $@"Click on the link to change your password
<a href='http://localhost:4200/forgot-password/{user.Email}' target='_blank'>Click to change your password
</a>";
        return body;
    }
}
