using AlternativeEngineerBlogServer.Application.Features.Users.Contacts.CreateContact;
using AlternativeEngineerBlogServer.Application.Features.Users.Links.CreateLink;
using AlternativeEngineerBlogServer.Application.Features.Users.UpdateUser;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;
//[Authorize(Roles = "Admin")]
public class UserController : ApiController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> UpdateUser(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContent(CreateContactCommand request,  CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLink(CreateLinkCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
}
