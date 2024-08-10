using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Users.UpdateUser;
public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required")
            .Length(2, 50)
            .WithMessage("First name must be between 2 and 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required")
            .Length(2, 50)
            .WithMessage("Last name must be between 2 and 50 characters");

        RuleFor(x => x.PhoneNumber)
            .Length(11)
            .WithMessage("Phone number length is 11 number");
    }
}
