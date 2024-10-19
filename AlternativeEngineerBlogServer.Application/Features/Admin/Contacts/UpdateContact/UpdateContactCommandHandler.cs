using AlternativeEngineerBlogServer.Domain.Contacts;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Contacts.UpdateContact;
internal class UpdateContactCommandHandler(
    IContactRepository contactRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateContactCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        Contact contact = await contactRepository.GetByExpressionAsync(p => p.Id == request.Id);
        if (contact is null)
        {
            return Result<string>.Failure("Mesaj bulunamadı");
        }

        contact.IsRead = true;
        contactRepository.Update(contact);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Mesaj okundu");
    }
}
