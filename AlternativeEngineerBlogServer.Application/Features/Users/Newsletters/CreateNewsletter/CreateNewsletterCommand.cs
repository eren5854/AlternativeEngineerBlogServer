using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Newsletters.CreateNewsletter;
public sealed record CreateNewsletterCommand(
    string Email) : IRequest<Result<string>>;
