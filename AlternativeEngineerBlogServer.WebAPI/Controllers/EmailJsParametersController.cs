using AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.CreateEmailJsParameter;
using AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.DeleteEmailJsParameterById;
using AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.GetAllEmailJsParameter;
using AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.UpdateEmailJsParameter;
using AlternativeEngineerBlogServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers
{
    public class EmailJsParametersController : ApiController
    {
        public EmailJsParametersController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateEmailJsParameter(CreateEmailJsParameterCommand request, CancellationToken cancellationToken)
        {
            var result  = await _mediator.Send(request, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmailJsParameter(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllEmailJsParameterQuery() ,cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmailJsParameter(UpdateEmailJsParameterCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteEmailJsParameterById(Guid Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteEmailJsParameterByIdCommand(Id) ,cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
