using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.SendConfirmEmail;
public sealed record SendConfirmEmailCommand(string Email) : IRequest<Result<string>>;
