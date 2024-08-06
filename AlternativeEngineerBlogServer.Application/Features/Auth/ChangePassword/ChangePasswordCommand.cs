using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.ChangePassword;
public sealed record ChangePasswordCommand(
    Guid Id,
    string CurrentPassword,
    string NewPassword) : IRequest<Result<string>>;
