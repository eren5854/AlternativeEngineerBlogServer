using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.UpdateCategory;
public sealed record UpdateCategoryCommand(
    Guid Id,
    string Name,
    Guid? MainCategoryId) : IRequest<Result<string>>;
