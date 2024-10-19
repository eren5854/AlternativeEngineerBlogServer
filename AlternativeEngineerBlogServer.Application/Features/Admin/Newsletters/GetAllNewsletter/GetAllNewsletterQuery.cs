using AlternativeEngineerBlogServer.Domain.Emails;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Newsletters.GetAllNewsletter;
public sealed record GetAllNewsletterQuery(): IRequest<Result<List<Newsletter>>>;
