using AlternativeEngineerBlogServer.Application.Features.Admin.Informations.CreateInformation;
using AlternativeEngineerBlogServer.Application.Features.Admin.Informations.DeleteInformationById;
using AlternativeEngineerBlogServer.Application.Features.Admin.Informations.GetInformation;
using AlternativeEngineerBlogServer.Application.Features.Admin.Informations.UpdateInformation;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

public class InformationsController : ApiController
{
    public InformationsController(IMediator mediator) : base(mediator)
    {
    }

    #region Information
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateInformation(CreateInformationCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> UpdateInformation(UpdateInformationCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> DeleteInformationById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteInformationByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetInformation(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetInformationQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
    #endregion
}
