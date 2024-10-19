using AlternativeEngineerBlogServer.Domain.EmailJsParameters;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.GetAllEmailJsParameter;
internal class GetAllEmailJsParameterQueryHandler(
    IEmailJsParameterRepository emailJsParameterRepository) : IRequestHandler<GetAllEmailJsParameterQuery, Result<List<EmailJsParameter>>>
{
    public async Task<Result<List<EmailJsParameter>>> Handle(GetAllEmailJsParameterQuery request, CancellationToken cancellationToken)
    {
        var emailJsparameters = await emailJsParameterRepository.GetAll().ToListAsync(cancellationToken);
        return Result<List<EmailJsParameter>>.Succeed(emailJsparameters);
    }
}
