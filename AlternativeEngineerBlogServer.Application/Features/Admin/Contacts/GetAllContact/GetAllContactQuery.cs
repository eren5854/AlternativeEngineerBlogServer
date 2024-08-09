using AlternativeEngineerBlogServer.Domain.Contacts;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Contacts.GetAllContact;
public sealed record GetAllContactQuery() : IRequest<Result<List<Contact>>>;
