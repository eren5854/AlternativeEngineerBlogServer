using AlternativeEngineerBlogServer.Domain.DTOs;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogById;
public sealed record GetBlogByIdCommand(Guid Id) : IRequest<Result<BlogDto>>;
