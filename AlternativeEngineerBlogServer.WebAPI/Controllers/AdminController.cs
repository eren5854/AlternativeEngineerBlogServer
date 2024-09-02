using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Authorize(Roles = "Admin")]

public class AdminController : ApiController
{
    public AdminController(IMediator mediator) : base(mediator)
    {
    }
}
