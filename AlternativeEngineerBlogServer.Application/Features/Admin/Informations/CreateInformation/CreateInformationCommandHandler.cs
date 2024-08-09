using AlternativeEngineerBlogServer.Domain.Informations;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using FluentValidation.Results;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.CreateInformation;
internal sealed class CreateInformationCommandHandler(
    IInformationRepository informationRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateInformationCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateInformationCommand request, CancellationToken cancellationToken)
    {
        CreateInformationCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);
        }

        Information information = mapper.Map<Information>(request);
        information.CreatedBy = "Admin";
        information.CreatedDate = DateTime.Now;

        await informationRepository.AddAsync(information, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Create is successfull");
    }
}
