using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.CreateBlog;
using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.DeleteBlogById;
using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetAllBlog;
using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogByAuthorId;
using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogById;
using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlog;
using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlogLikeCount;
using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.UpdateBlogViewCount;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

public class BlogsController : ApiController
{
    public BlogsController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Author")]
    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromForm] CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Author")]
    [HttpPost]
    public async Task<IActionResult> UpdateBlog([FromForm] UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBlog(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllBlogQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBlogByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Author, Admin")]
    [HttpGet]
    public async Task<IActionResult> GetBlogByAuthorId(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBlogByAuthorIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Author, Admin")]
    [HttpGet]
    public async Task<IActionResult> DeleteBlogById(Guid Id, Guid appUserId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteBlogByIdCommand(Id, appUserId), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBlogViewCount(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateBlogViewCountCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBlogLikeCount(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateBlogLikeCountCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
}
