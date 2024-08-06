﻿using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.Register;
public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required").Length(2, 30).WithMessage("First name must be between 2 and 50 characters");

        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required").Length(2, 30).WithMessage("Last name must be between 2 and 50 characters");

        RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required").Length(3, 30).WithMessage("User name must be between 3 and 50 characters");

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("A valid email is required");

        RuleFor(x => x.PhoneNumber).Length(11).WithMessage("Phone number length is 11 number");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\!\?\*\.\@\#]").WithMessage("Password must contain at least one special character (!?*.@#).");
    }
}
