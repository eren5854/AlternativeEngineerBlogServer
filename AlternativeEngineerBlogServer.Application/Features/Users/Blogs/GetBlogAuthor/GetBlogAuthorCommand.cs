using AlternativeEngineerBlogServer.Domain.DTOs;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogAuthor;
public sealed record GetBlogAuthorCommand(Guid Id) : IRequest<Result<GetBlogAuthorDto>>;
