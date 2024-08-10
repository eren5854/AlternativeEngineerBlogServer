using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Contacts.CreateContact;
public sealed class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(p => p.ContactName)
            .NotEmpty()
            .WithMessage("İsim alanı boş olamaz")
            .MaximumLength(50)
            .WithMessage("İsim alanı maksimum 50 karakter olmalı");

        RuleFor(p => p.ContactEmail)
            .NotEmpty()
            .WithMessage("Mail alanı boş olamaz")
            .MaximumLength(50)
            .WithMessage("Mail alanı maksimum 50 karakter olmalı");

        RuleFor(p => p.Subject)
            .NotEmpty()
            .WithMessage("Konu alanı boş olamaz")
            .MaximumLength(100)
            .WithMessage("Konu alanı maksimum 100 karakter olmalı");

        RuleFor(p => p.Content)
            .NotEmpty()
            .WithMessage("Mesaj alanı boş olamaz")
            .MaximumLength(1000)
            .WithMessage("Mesaj alanı maksimum 1000 karakter olmalı");
    }
}
