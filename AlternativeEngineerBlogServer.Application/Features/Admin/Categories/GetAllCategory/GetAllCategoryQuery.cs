using AlternativeEngineerBlogServer.Domain.Categories;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Categories.GetAllCategory;
public sealed record GetAllCategoryQuery() : IRequest<Result<List<Category>>>;
