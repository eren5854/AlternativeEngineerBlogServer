using AlternativeEngineerBlogServer.Domain.Categories;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Categories.GetCategoryById;
internal sealed class GetCategoryByIdCommandHandler(
    ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryByIdCommand, Result<Category>>
{
    public async Task<Result<Category>> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        Category category = await categoryRepository.GetByExpressionAsync(p => p.Id == request.Id);
        if(category is null)
        {
            return Result<Category>.Failure("Category not found");
        }

        return category;
    }
}
