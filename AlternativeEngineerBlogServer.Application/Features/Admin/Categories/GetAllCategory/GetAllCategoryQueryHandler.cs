using AlternativeEngineerBlogServer.Domain.Categories;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.GetAllCategory;
internal sealed class GetAllCategoryQueryHandler(
    ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoryQuery, Result<List<Category>>>
{
    public async Task<Result<List<Category>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var response = await categoryRepository
            .GetAll()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
        return Result<List<Category>>.Succeed(response);
    }
}
