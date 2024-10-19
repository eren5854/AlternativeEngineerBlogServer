using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Newsletters.CreateNewsletter;
public sealed class CreateNewsletterCommandValidator : AbstractValidator<CreateNewsletterCommand>
{
    public CreateNewsletterCommandValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .WithMessage("E-posta alanı boş olamaz")
            .MaximumLength(150)
            .WithMessage("E-posta alanı maksimum 150 karakter olmalı");
    }
}
