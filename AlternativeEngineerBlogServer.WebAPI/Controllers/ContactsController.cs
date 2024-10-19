using AlternativeEngineerBlogServer.Application.Features.Admin.Contacts.DeleteContactById;
using AlternativeEngineerBlogServer.Application.Features.Admin.Contacts.GetAllContact;
using AlternativeEngineerBlogServer.Application.Features.Admin.Contacts.UpdateContact;
using AlternativeEngineerBlogServer.Application.Features.Users.Contacts.CreateContact;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

public class ContactsController : ApiController
{
    public ContactsController(IMediator mediator) : base(mediator)
    {
    }

    #region Contact
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllContact(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllContactQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> DeleteContactById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteContactByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Update(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateContactCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
    #endregion
}
