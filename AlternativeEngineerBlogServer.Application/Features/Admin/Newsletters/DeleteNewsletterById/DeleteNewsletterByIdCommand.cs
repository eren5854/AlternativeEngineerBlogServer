using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Newsletters.DeleteNewsletter;
public sealed record DeleteNewsletterByIdCommand(
    Guid Id) : IRequest<Result<string>>;