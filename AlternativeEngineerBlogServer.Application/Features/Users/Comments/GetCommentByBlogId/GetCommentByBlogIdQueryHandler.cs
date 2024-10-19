using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Comments.GetCommentByBlogId;
internal sealed class GetCommentByBlogIdQueryHandler(
    ICommentRepository commentRepository) : IRequestHandler<GetCommentByBlogIdQuery, Result<List<CommentDto>>>
{
    public async Task<Result<List<CommentDto>>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await commentRepository
            .Where(p => p.BlogId == request.Id)
            .Select(s => new CommentDto(
                s.Id,
                s.Content,
                s.MainCommentId,
                s.CreatedDate,
                new GetCommentUserDto(
                    s.AppUser!.UserName,
                    s.AppUser.Role)))
            .ToListAsync(cancellationToken);

        var sortedCommnets = comments.OrderByDescending(o => o.CreatedDate).ToList();

        return Result<List<CommentDto>>.Succeed(sortedCommnets);
    }
}
