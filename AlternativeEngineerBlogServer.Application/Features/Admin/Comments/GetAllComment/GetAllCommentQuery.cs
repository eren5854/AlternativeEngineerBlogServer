using AlternativeEngineerBlogServer.Domain.Comments;
using AlternativeEngineerBlogServer.Domain.DTOs;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Comments.GetAllComment;
public sealed record GetAllCommentQuery() : IRequest<Result<List<GetAllCommentDto>>>;
