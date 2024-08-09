using AlternativeEngineerBlogServer.Domain.Informations;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using FluentValidation.Results;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.UpdateInformation;
internal sealed class UpdateInformationCommandHandler(
    IInformationRepository informationRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateInformationCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateInformationCommand request, CancellationToken cancellationToken)
    {
        UpdateInformationCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);
        }

        Information information = await informationRepository.GetByExpressionAsync(p => p.Id == request.Id);
        if (information is null)
        {
            return Result<string>.Failure("Informations not found");
        }

        mapper.Map(request, information);
        information.UpdatedBy = "Admin";
        information.UpdatedDate = DateTime.Now;

        informationRepository.Update(information);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Update is successful");
    }
}
