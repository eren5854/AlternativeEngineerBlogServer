using AlternativeEngineerBlogServer.Domain.Users;
using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.SetAuthorRoleForUsers;
public sealed class SetAuthorRoleForUsersCommandValidator : AbstractValidator<SetAuthorRoleForUsersCommand>
{
    public SetAuthorRoleForUsersCommandValidator()
    {
        RuleFor(x => x.Role.Name)
            .NotEmpty()
            .Must(roleName => 
                        roleName == UserRoleSmartEnum.User.Name || 
                        roleName == UserRoleSmartEnum.Author.Name)
            .WithMessage("Role must be either 'User(3)' or 'Author(2)'.");

        RuleFor(x => x.Role.Value)
            .NotEmpty()
            .Must(roleValue => 
                        roleValue == UserRoleSmartEnum.User.Value || 
                        roleValue == UserRoleSmartEnum.Author.Value)
            .WithMessage("Role must be either 'User(3)' or 'Author(2)'.");
    }
}
