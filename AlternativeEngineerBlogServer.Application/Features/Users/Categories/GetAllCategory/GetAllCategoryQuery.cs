using AlternativeEngineerBlogServer.Domain.Categories;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Categories.GetAllCategory;
public sealed record GetAllCategoryQuery() : IRequest<Result<List<Category>>>;
