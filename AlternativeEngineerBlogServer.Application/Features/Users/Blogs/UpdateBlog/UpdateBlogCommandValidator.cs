using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlog;
public sealed class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("Id alanı boş olamaz!");

        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage("Başlık alanı boş olamaz!")
            .MaximumLength(50)
            .WithMessage("Başlık alanı maksimum 50 karakter olmalı!");

        RuleFor(p => p.SubTitle)
            .NotEmpty()
            .WithMessage("Alt başlık alanı boş olamaz!")
            .MaximumLength(100)
            .WithMessage("Alt başlık alanı maksimum 100 karakter olmalı!");

        RuleFor(x => x.MainImage)
               .Must(BeAValidImage).WithMessage("MainImage must be a valid image file.")
               .When(x => x.MainImage != null);

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MinimumLength(10).WithMessage("Content must be at least 10 characters long.");

        RuleFor(x => x.AppUserId)
            .NotEmpty().WithMessage("AppUserId is required.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.");
    }

    private bool BeAValidImage(IFormFile? file)
    {
        if (file == null)
            return true;

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var extension = Path.GetExtension(file.FileName)?.ToLower();

        return allowedExtensions.Contains(extension);
    }
}
