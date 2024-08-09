using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.CreateInformation;
public sealed class CreateInformationCommandValidator : AbstractValidator<CreateInformationCommand>
{
    public CreateInformationCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(30)
            .WithMessage("Title karakter sayısı maksimum 30 olmalı");


        RuleFor(x => x.SubTitle)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Subtitle karakter sayısı maksimum 50 olmalı");

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(300)
            .WithMessage("Description karakter sayısı maksimum 300 olmalı");
        
        RuleFor(x => x.Address)
           .NotEmpty()
           .MaximumLength(100)
           .WithMessage("Address karakter sayısı maksimum 100 olmalı");

        RuleFor(x => x.PhoneNumber)
           .Length(11)
           .WithMessage("Phone Number karakter sayısı 11 olmalı")
           .Matches(@"[0-9]")
           .WithMessage("Phone number sadece rakamlardan oluşmalı.");

        RuleFor(x => x.LinkedinUrl)
          .MaximumLength(50)
          .WithMessage("LinkedinUrl karakter sayısı maksimum 50 olmalı");

        RuleFor(x => x.InstagramUrl)
          .MaximumLength(50)
          .WithMessage("InstagramUrl karakter sayısı maksimum 50 olmalı");

        RuleFor(x => x.XUrl)
          .MaximumLength(50)
          .WithMessage("XUrl karakter sayısı maksimum 50 olmalı");

        RuleFor(x => x.GithubUrl)
          .MaximumLength(50)
          .WithMessage("GithubUrl karakter sayısı maksimum 50 olmalı");
    }
}
