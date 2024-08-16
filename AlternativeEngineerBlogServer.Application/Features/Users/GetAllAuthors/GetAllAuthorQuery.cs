using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.GetAllAuthors;
public sealed record GetAllAuthorQuery() : IRequest<Result<List<GetAuthorDto>>>;
