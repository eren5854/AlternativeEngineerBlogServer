using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Contacts.DeleteContactById;
public sealed record DeleteContactByIdCommand(Guid Id) : IRequest<Result<string>>;
