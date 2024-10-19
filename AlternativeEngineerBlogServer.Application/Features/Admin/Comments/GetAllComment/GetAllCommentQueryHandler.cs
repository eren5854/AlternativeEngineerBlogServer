using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Comments.GetAllComment;
internal sealed class GetAllCommentQueryHandler(
    ICommentRepository commentRepository) : IRequestHandler<GetAllCommentQuery, Result<List<GetAllCommentDto>>>
{
    public async Task<Result<List<GetAllCommentDto>>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
    {
        var comments = await commentRepository
            .GetAll().Select(s => new GetAllCommentDto(
                s.Id,
                s.Content,
                s.BlogId,
                s.MainCommentId,
                s.CreatedDate,
                s.AppUserId,
                new GetCommentUserDto(
                    s.AppUser!.UserName,
                    s.AppUser.Role)))
            .ToListAsync(cancellationToken);

        var sortedComments = comments.OrderBy(o => o.CreatedDate).ToList();

        return Result<List<GetAllCommentDto>>.Succeed(sortedComments);
    }
}
