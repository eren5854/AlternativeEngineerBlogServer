using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.GetUserById;
public sealed record GetUserByIdCommand(Guid Id) : IRequest<Result<AppUser>>;
