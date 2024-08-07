using AlternativeEngineerBlogServer.Application.Features.Admin.Categories.CreateCategory;
using AlternativeEngineerBlogServer.Application.Features.Admin.Categories.UpdateCategory;
using AlternativeEngineerBlogServer.Application.Features.Admin.GetAllAuthors;
using AlternativeEngineerBlogServer.Application.Features.Admin.GetAllUser;
using AlternativeEngineerBlogServer.Application.Features.Admin.SetAuthorRoleForUsers;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Authorize(Roles = "Admin")]

public class AdminController : ApiController
{
    public AdminController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllUserQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> SetAuthorRoleForUsers(SetAuthorRoleForUsersCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAllAuthors(CancellationToken cancellationToken)
    //{
    //    var result = await _mediator.Send(new GetAllAuthorQuery(), cancellationToken);
    //    return StatusCode(result.StatusCode, result);
    //}

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
}
