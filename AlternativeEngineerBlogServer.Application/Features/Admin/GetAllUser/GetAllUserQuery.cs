using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.GetAllUser;
public sealed record GetAllUserQuery(): IRequest<Result<List<AppUser>>>;
