using AlternativeEngineerBlogServer.Domain.Contacts;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using FluentValidation.Results;
using GenericEmailService;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Contacts.CreateContact;
internal sealed class CreateContactCommandHandler(
    IContactRepository contactRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateContactCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        CreateContactCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);
        }

        Contact contact = mapper.Map<Contact>(request);
        contact.CreatedBy = request.ContactName;
        contact.CreatedDate = DateTime.Now;
        
        await contactRepository.AddAsync(contact, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        string body = CreateBody(contact);
        string subject = contact.Subject;

        EmailConfigurations emailConfigurations = new(
           "smtp-mail.outlook.com",
           "ypfppzbkknupvsvc",
           587,
           false,
           true);

        EmailModel<Stream> emailModel = new(
            emailConfigurations,
            "erendelibas58@outlook.com",
            new List<string> { "erendelibas58@outlook.com" ?? "" },
            subject,
            body,
            null);
        
        await EmailService.SendEmailWithMailKitAsync(emailModel);
        return Result<string>.Succeed("Mesaj gönderildi");
    }

    private string CreateBody(Contact contact)
    {
        string body = $@"
<h4>Gönderen Adı: {contact.ContactName}</h3>
<h4>Gönderen Email: {contact.ContactEmail}</h3>
<h3>Mesaj: {contact.Content}</h2>";
        return body;
    }
}
