using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Contacts.UpdateContact;
public sealed record UpdateContactCommand(
    Guid Id) : IRequest<Result<string>>;
