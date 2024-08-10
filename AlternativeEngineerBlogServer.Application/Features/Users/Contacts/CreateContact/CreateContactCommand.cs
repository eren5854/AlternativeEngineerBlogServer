using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Contacts.CreateContact;
public sealed record CreateContactCommand(
    string ContactName,
    string ContactEmail,
    string Subject,
    string Content) : IRequest<Result<string>>;
