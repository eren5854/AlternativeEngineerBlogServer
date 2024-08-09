using AlternativeEngineerBlogServer.Application.Features.Admin.Categories.CreateCategory;
using AlternativeEngineerBlogServer.Application.Features.Admin.Categories.DeleteCategoryById;
using AlternativeEngineerBlogServer.Application.Features.Admin.Categories.GetAllCategory;
using AlternativeEngineerBlogServer.Application.Features.Admin.Categories.UpdateCategory;
using AlternativeEngineerBlogServer.Application.Features.Admin.Users.GetAllAuthors;
using AlternativeEngineerBlogServer.Application.Features.Admin.Users.GetAllUser;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlternativeEngineerBlogServer.Application.Features.Admin.Users.DeleteUserById;
using AlternativeEngineerBlogServer.Application.Features.Admin.Users.SetAuthorRoleForUsers;
using AlternativeEngineerBlogServer.Application.Features.Admin.Informations.CreateInformation;
using AlternativeEngineerBlogServer.Application.Features.Admin.Informations.UpdateInformation;
using AlternativeEngineerBlogServer.Application.Features.Admin.Informations.DeleteInformationById;
using AlternativeEngineerBlogServer.Application.Features.Admin.Informations.GetInformation;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

//[Authorize(AuthenticationSchemes = "Bearer")]
//[Authorize(Roles = "Admin")]

public class AdminController : ApiController
{
    public AdminController(IMediator mediator) : base(mediator)
    {
    }

    #region User
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

    [HttpGet]
    public async Task<IActionResult> DeleteUserById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteUserByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAllAuthors(CancellationToken cancellationToken)
    //{
    //    var result = await _mediator.Send(new GetAllAuthorQuery(), cancellationToken);
    //    return StatusCode(result.StatusCode, result);
    //}
    #endregion

    #region Category
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

    [HttpGet]
    public async Task<IActionResult> DeleteCategoryById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteCategoryByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategory(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllCategoryQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
    #endregion

    #region Information
    [HttpPost]
    public async Task<IActionResult> CreateInformation(CreateInformationCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateInformation(UpdateInformationCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

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
