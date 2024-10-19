using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using ED.GenericRepository;
using ED.Result;
using GenericEmailService;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.SendForgotPasswordEmail;
internal sealed class SendForgotPasswordEmailCommandHandler(
    UserManager<AppUser> userManager,
    IAppUserRepository appUserRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<SendForgotPasswordEmailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(SendForgotPasswordEmailCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        Random random = new();
        user.ForgotPasswordCode = random.Next(100000, 999999);  // 6 haneli kod oluştur
        user.ForgotPasswordCodeSendDate = DateTime.Now;

        appUserRepository.Update(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        string body = CreateBody(user.ForgotPasswordCode, user.Email);
        string subject = "Şifremi Unuttum";

        EmailConfigurations emailConfigurations = new(
           "smtpout.secureserver.net",
           "***",
           465,
           true,
           true);

        EmailModel<Stream> emailModel = new(
            emailConfigurations,
            "mail@gmail.com",
            new List<string> { user.Email ?? "" },
            subject,
            body,
            null);

        await EmailService.SendEmailWithMailKitAsync(emailModel);

        return Result<string>.Succeed("Şifremi unuttum maili gönderildi");
    }

    private string CreateBody(int? code, string? email)
    {
        string body = $@"Şifrenizi değiştirmek için aşağıdaki linke tıklayın: 
<a href='https://link/forgot-password/{email}{code}' target='_blank'>https://link/forgot-password/{email}{code}
</a>";
        return body;
    }
}
