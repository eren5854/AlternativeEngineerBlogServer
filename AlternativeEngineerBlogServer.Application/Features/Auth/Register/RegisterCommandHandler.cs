using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.Result;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.Register;
internal class RegisterCommandHandler(
    UserManager<AppUser> userManager,
    IMapper mapper) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        RegisterCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);
        }

        bool isEmailExists = await userManager.Users.AnyAsync(p => p.Email == request.Email);
        if (isEmailExists)
        {
            return Result<string>.Failure("Email alredy exists");
        }

        bool isUserNameExists = await userManager.Users.AnyAsync(p => p.UserName == request.UserName);
        if (isUserNameExists)
        {
            return Result<string>.Failure("User name alredy exists");
        }

        AppUser user = mapper.Map<AppUser>(request);
        user.CreatedBy = request.UserName;
        user.Gender = UserGenderEnum.Belirtilmemiş;
        //user.EmailConfirmed = true;
        user.CreatedDate = DateTime.Now;
        user.Role = UserRoleSmartEnum.User;

        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Record could not be created");
        }
        return Result<string>.Succeed("User registration successful");
    }
}
