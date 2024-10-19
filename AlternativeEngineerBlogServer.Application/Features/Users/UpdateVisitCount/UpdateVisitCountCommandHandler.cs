using AlternativeEngineerBlogServer.Domain.Informations;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.UpdateVisitCount;
internal sealed class UpdateVisitCountCommandHandler(
    IInformationRepository informationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateVisitCountCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateVisitCountCommand request, CancellationToken cancellationToken)
    {
        Information information = await informationRepository.GetByExpressionAsync(p => p.Id == request.Id);
        if (information is null)
        {
            return Result<string>.Failure("Site bilgisi bulunamadı");
        }

        information.VisitCount++;
        informationRepository.Update(information);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Ziyaretçi sayısı güncellendi");
    }
}
