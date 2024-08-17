using AlternativeEngineerBlogServer.Domain.Categories;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Categories.GetCategoryById;
public sealed record GetCategoryByIdCommand(Guid Id) : IRequest<Result<Category>>;
