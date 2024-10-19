using AlternativeEngineerBlogServer.Domain.EmailJsParameters;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.CreateEmailJsParameter;
internal sealed class CreateEmailJsParameterCommandHandler(
    IEmailJsParameterRepository emailJsParameterRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateEmailJsParameterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateEmailJsParameterCommand request, CancellationToken cancellationToken)
    {
        EmailJsParameter emailJsParameter = mapper.Map<EmailJsParameter>(request);
        emailJsParameter.CreatedDate = DateTime.Now;
        emailJsParameter.CreatedBy = "Admin";

        await emailJsParameterRepository.AddAsync(emailJsParameter, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Email Js parametreleri kaydı başarılı");
    }
}
