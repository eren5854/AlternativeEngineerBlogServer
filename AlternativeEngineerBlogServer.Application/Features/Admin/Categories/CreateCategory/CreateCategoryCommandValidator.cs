using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.CreateCategory;
public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
    }
}
