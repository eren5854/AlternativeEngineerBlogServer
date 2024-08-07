using AlternativeEngineerBlogServer.Domain.Categories;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using FluentValidation.Results;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.CreateCategory;
internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        CreateCategoryCommandValidator validator = new();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<string>.Failure(validationResult.Errors.First().ErrorMessage);
        }

        var isCategoryExists = await categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (isCategoryExists)
        {
            return Result<string>.Succeed("category is already exists");
        }

        Category category = mapper.Map<Category>(request);
        category.CreatedBy = "Admin";
        category.CreatedDate = DateTime.Now;

        await categoryRepository.AddAsync(category, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Category create is successful");
    }
}
