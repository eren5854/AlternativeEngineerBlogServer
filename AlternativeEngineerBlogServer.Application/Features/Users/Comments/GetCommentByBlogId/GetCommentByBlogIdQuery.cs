using AlternativeEngineerBlogServer.Domain.DTOs;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.GetCommentByBlogId;
public sealed record GetCommentByBlogIdQuery(
    Guid Id) : IRequest<Result<List<CommentDto>>>;
