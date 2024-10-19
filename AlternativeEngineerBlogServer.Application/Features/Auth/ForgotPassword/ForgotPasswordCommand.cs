using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.ForgotPassword;
public sealed record ForgotPasswordCommand(
    string Email,
    int ForgotPasswordCode) : IRequest<Result<string>>;
