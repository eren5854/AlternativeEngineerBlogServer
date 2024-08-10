using AlternativeEngineerBlogServer.Domain.Contacts;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Contacts.DeleteContactById;
internal sealed class DeleteContactByIdCommandHandler(
    IContactRepository contactRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteContactByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteContactByIdCommand request, CancellationToken cancellationToken)
    {
        Contact contact = await contactRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (contact is null)
        {
            return Result<string>.Failure("User not found");
        }

        contact.IsDeleted = true;
        contactRepository.Update(contact);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Delete is successful");
    }
}
