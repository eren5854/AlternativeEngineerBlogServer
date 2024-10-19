using AlternativeEngineerBlogServer.Application.Features.Admin.Comments.GetAllComment;
using AlternativeEngineerBlogServer.Application.Features.Users.Comments.CreateComment;
using AlternativeEngineerBlogServer.Application.Features.Users.Comments.DeleteCommentById;
using AlternativeEngineerBlogServer.Application.Features.Users.Comments.GetCommentByBlogId;
using AlternativeEngineerBlogServer.Application.Features.Users.Comments.UpdateComment;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

public class CommentsController : ApiController
{
    public CommentsController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin, Author, User")]
    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetCommentByBlogId(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCommentByBlogIdQuery(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin, Author, User")]
    [HttpPost]
    public async Task<IActionResult> UpdateComment(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin, Author, User")]
    [HttpPost]
    public async Task<IActionResult> DeleteCommentById(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllComment(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllCommentQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
}
