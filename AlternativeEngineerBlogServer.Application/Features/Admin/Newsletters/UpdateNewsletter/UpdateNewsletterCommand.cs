using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Newsletters.UpdateNewsletter;
public sealed record UpdateNewsletterCommand(
    Guid Id,
    bool IsActive) : IRequest<Result<string>>;
