using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.CreateBlog;
using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetAllBlog;
using AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetBlogById;
using AlternativeEngineerBlogServer.Application.Features.Users.Categories.GetAllCategory;
using AlternativeEngineerBlogServer.Application.Features.Users.Categories.GetCategoryById;
using AlternativeEngineerBlogServer.Application.Features.Users.Contacts.CreateContact;
using AlternativeEngineerBlogServer.Application.Features.Users.GetAllAuthors;
using AlternativeEngineerBlogServer.Application.Features.Users.GetInformation;
using AlternativeEngineerBlogServer.Application.Features.Users.GetUserById;
using AlternativeEngineerBlogServer.Application.Features.Users.Links.CreateLink;
using AlternativeEngineerBlogServer.Application.Features.Users.Links.DeleteLinkById;
using AlternativeEngineerBlogServer.Application.Features.Users.Links.GetLinkById;
using AlternativeEngineerBlogServer.Application.Features.Users.Links.UpdateLink;
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
    [HttpGet]
    public async Task<IActionResult> GetUserById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> UpdateUser([FromForm]UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactCommand request,  CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
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

    [HttpGet]
    public async Task<IActionResult> GetAllAuthors(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllAuthorQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetInformation(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetInformationQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogCommand request, CancellationToken cancellationToken)
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
    public async Task<IActionResult> GetAllCategory(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllCategoryQuery(), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoryById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCategoryByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogById(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBlogByIdCommand(Id), cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
}
