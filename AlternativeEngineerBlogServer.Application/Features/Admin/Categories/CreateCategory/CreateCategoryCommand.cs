using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.CreateCategory;
public sealed record CreateCategoryCommand(
    string Name,
    Guid? MainCategoryId) : IRequest<Result<string>>;
