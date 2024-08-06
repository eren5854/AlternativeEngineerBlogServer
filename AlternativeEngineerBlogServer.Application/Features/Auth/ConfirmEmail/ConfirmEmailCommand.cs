using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.ConfirmEmail;
public sealed record ConfirmEmailCommand(string Email): IRequest<Result<string>>;
