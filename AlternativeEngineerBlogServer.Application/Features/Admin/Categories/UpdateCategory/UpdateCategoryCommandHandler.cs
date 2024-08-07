using AlternativeEngineerBlogServer.Domain.Categories;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.UpdateCategory;
internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await categoryRepository.GetByExpressionAsync(p => p.Id == request.Id);
        if (category is null)
        {
            return Result<string>.Failure("Category not found");
        }

        mapper.Map(request, category);
        category.UpdatedBy = "Admin";
        category.UpdatedDate = DateTime.Now;

        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Category update is successful");

    }
}
