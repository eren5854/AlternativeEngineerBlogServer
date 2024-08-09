using AlternativeEngineerBlogServer.Domain.Categories;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.DeleteCategoryById;
internal sealed class DeleteCategoryByIdCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        Category category = await categoryRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (category is null)
        {
            return Result<string>.Failure("User not found");
        }

        category.IsDeleted = true;
        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Delete is successful");
    }
}
