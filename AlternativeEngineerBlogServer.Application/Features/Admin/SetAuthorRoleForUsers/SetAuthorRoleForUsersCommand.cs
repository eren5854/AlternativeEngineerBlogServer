using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.SetAuthorRoleForUsers;
public sealed record SetAuthorRoleForUsersCommand(
    Guid Id,
    UserRoleSmartEnum Role) : IRequest<Result<string>>;
