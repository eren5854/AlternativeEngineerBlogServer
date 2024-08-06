using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.Result;
using FluentValidation.Results;
using GenericFileService.Files;
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
            throw new ArgumentException(string.Join(", ", validationResult.Errors));
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

        string profilePicture = "";
        var response = request.ProfilePicture;
        if (response is null)
        {
            profilePicture = "";
        }
        else
        {
            profilePicture = FileService.FileSaveToServer(request.ProfilePicture, "wwwroot/ProfilePictures/");
        }

        AppUser user = mapper.Map<AppUser>(request);
        user.ProfilePicture = profilePicture;
        user.CreatedBy = request.UserName;
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
