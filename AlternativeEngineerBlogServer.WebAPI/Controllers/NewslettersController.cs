using AlternativeEngineerBlogServer.Application.Features.Admin.Newsletters.DeleteNewsletter;
using AlternativeEngineerBlogServer.Application.Features.Admin.Newsletters.GetAllNewsletter;
using AlternativeEngineerBlogServer.Application.Features.Admin.Newsletters.UpdateNewsletter;
using AlternativeEngineerBlogServer.Application.Features.Users.Newsletters.CreateNewsletter;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

public class NewslettersController : ApiController
{
    public NewslettersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewsletter(CreateNewsletterCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNewsletter(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllNewsletterQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateNewsletter(UpdateNewsletterCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteNewsletterById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteNewsletterByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
}
