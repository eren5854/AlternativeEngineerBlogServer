using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.CreateComment;
public sealed class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(p => p.Content)
            .NotEmpty()
            .WithMessage("Yorum alanı boş olamaz")
            .MaximumLength(1000)
            .WithMessage("Yorum maksimum 1000 karakter olmalı");

        RuleFor(p => p.AppUserId)
            .NotEmpty()
            .WithMessage("Kullanıcı kimliği gönderilemedi");

        RuleFor(p => p.BlogId)
           .NotEmpty()
           .WithMessage("Blog bilgileri gönderilemedi");
    }
}
