using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using FluentValidation.Results;
using GenericFileService.Files;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.UpdateUser;
internal sealed class UpdateUserCommandHandler(
    IAppUserRepository appUserRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        UpdateUserCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);
        }

        AppUser user = await appUserRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (user == null)
        {
            return Result<string>.Failure("Kullanıcı bulunamadı!");
        }

        bool isUserNameExists = await appUserRepository.AnyAsync(p => p.UserName == request.UserName, cancellationToken);
        if (isUserNameExists && user.UserName != request.UserName)
        {
            
            return Result<string>.Failure("Kullanıcı adı zaten mevcut!");
        }
        
        string profilePicture = "";
        var response = request.ProfilePicture;
        if (response is null)
        {
            profilePicture = user.ProfilePicture!;
        }
        else
        {
            profilePicture = FileService.FileSaveToServer(request.ProfilePicture!, "wwwroot/ProfilePictures/");
        }

        mapper.Map(request, user);
        user.ProfilePicture = profilePicture;
        user.UpdatedBy = user.FirstName;
        user.UpdatedDate = DateTime.Now;

        appUserRepository.Update(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Kullanıcı güncellemesi başarılı.");
    }
}
