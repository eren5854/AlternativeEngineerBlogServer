using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.GetAllAuthors;
public sealed record GetAllAuthorQuery() : IRequest<Result<List<AppUser>>>;
