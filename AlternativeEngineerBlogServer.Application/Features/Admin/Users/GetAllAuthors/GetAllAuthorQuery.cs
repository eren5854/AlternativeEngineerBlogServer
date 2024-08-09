using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Users.GetAllAuthors;
public sealed record GetAllAuthorQuery() : IRequest<Result<List<AppUser>>>;
