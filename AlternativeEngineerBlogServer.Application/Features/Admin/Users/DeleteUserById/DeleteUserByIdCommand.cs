using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Users.DeleteUserById;
public sealed record DeleteUserByIdCommand(
    Guid Id) : IRequest<Result<string>>;
