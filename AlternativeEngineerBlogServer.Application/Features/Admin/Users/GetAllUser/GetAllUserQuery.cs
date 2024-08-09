using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Users.GetAllUser;
public sealed record GetAllUserQuery() : IRequest<Result<List<AppUser>>>;
