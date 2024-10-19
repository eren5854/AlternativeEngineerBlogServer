using AlternativeEngineerBlogServer.Domain.EmailJsParameters;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.UpdateEmailJsParameter;
internal sealed class UpdateEmailJsParameterCommandHandler(
    IEmailJsParameterRepository emailJsParameterRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateEmailJsParameterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateEmailJsParameterCommand request, CancellationToken cancellationToken)
    {
        EmailJsParameter emailJsParameter = await emailJsParameterRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (emailJsParameter is null)
        {
            return Result<string>.Failure("Email Js Parameters not found");
        }

        mapper.Map(request, emailJsParameter);
        emailJsParameter.UpdatedDate = DateTime.Now;
        emailJsParameter.UpdatedBy = "Admin";

        emailJsParameterRepository.Update(emailJsParameter);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Email Js Paremeters update is successfull");
    }
}
