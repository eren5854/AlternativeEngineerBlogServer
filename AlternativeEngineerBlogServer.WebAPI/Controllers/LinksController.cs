using AlternativeEngineerBlogServer.Application.Features.Users.Links.CreateLink;
using AlternativeEngineerBlogServer.Application.Features.Users.Links.DeleteLinkById;
using AlternativeEngineerBlogServer.Application.Features.Users.Links.GetLinkById;
using AlternativeEngineerBlogServer.Application.Features.Users.Links.UpdateLink;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

public class LinksController : ApiController
{
    public LinksController(IMediator mediator) : base(mediator)
    {
    }

    #region Links
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> CreateLink(CreateLinkCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> UpdateLink(UpdateLinkCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> GetLinkById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetLinkByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> DeleteLinkById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteLinkByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
    #endregion
}
