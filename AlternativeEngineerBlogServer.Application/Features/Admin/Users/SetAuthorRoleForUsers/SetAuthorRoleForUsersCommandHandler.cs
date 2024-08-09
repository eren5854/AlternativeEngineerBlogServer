using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using FluentValidation.Results;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Users.SetAuthorRoleForUsers;
internal sealed class SetAuthorRoleForUsersCommandHandler(
    IAppUserRepository appUserRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<SetAuthorRoleForUsersCommand, Result<string>>
{
    public async Task<Result<string>> Handle(SetAuthorRoleForUsersCommand request, CancellationToken cancellationToken)
    {
        SetAuthorRoleForUsersCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);

        }
        AppUser? user = await appUserRepository.GetByExpressionAsync(p => p.Id == request.Id);
        if (user == null)
        {
            return Result<string>.Failure("User not found");
        }

        mapper.Map(request, user);
        user.CreatedBy = "Admin";
        user.CreatedDate = DateTime.Now;

        appUserRepository.Update(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed($"{user.UserName} kişisinin rolü {request.Role} olarak değiştirildi");
    }
}
