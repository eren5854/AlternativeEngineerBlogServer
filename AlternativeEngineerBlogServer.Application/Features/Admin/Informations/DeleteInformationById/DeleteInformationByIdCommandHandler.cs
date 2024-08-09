using AlternativeEngineerBlogServer.Domain.Informations;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.DeleteInformationById;
internal sealed class DeleteInformationByIdCommandHandler(
    IInformationRepository informationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteInformationByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteInformationByIdCommand request, CancellationToken cancellationToken)
    {
        Information information = await informationRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (information is null)
        {
            return Result<string>.Failure("Information not found");
        }

        information.IsDeleted = true;
        informationRepository.Update(information);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Delete is successful");
    }
}
