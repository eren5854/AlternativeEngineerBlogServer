using AlternativeEngineerBlogServer.Domain.DTOs;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogByAuthorId;
public sealed record GetBlogByAuthorIdCommand(Guid Id) : IRequest<Result<List<GetBlogByAuthorDto>>>;
