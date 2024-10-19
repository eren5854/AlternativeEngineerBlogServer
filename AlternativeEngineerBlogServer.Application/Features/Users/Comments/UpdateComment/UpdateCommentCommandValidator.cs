using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.UpdateComment;
public sealed class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("Yorum kimliği boş olamaz");

        RuleFor(p => p.Content)
            .NotEmpty()
            .WithMessage("Yorum alanı boş olamaz")
            .MaximumLength(1000)
            .WithMessage("Yorum maksimum 1000 karakter olmalı");
    }
}
