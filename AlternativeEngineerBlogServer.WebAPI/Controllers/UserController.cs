using AlternativeEngineerBlogServer.Application.Features.Admin.Users.DeleteUserById;
using AlternativeEngineerBlogServer.Application.Features.Admin.Users.GetAllUser;
using AlternativeEngineerBlogServer.Application.Features.Admin.Users.SetAuthorRoleForUsers;
using AlternativeEngineerBlogServer.Application.Features.Users.GetAllAuthors;
using AlternativeEngineerBlogServer.Application.Features.Users.GetUserById;
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

    #region User
    [Authorize(AuthenticationSchemes = "Bearer")]
    //[Authorize(Roles = "Author, User, Admin")]
    [HttpGet]
    public async Task<IActionResult> GetUserById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    //[Authorize(Roles = "Author")]
    [HttpPost]
    public async Task<IActionResult> UpdateUser([FromForm]UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllUser(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllUserQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SetAuthorRoleForUsers(SetAuthorRoleForUsersCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> DeleteUserById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteUserByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthors(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllAuthorQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
    #endregion
}
