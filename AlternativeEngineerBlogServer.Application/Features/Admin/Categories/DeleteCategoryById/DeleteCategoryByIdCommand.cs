using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.DeleteCategoryById;
public sealed record DeleteCategoryByIdCommand(
    Guid Id) : IRequest<Result<string>>;
