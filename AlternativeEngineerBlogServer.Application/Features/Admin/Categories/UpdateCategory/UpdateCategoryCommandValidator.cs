using FluentValidation;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.UpdateCategory;
public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
    }
}
