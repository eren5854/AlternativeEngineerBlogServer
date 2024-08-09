using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;

public class UserController : ApiController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }
}
