using AlternativeEngineerBlogServer.Domain.EmailJsParameters;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.DeleteEmailJsParameterById;
internal sealed class DeleteEmailJsParameterByIdCommandHandler(
    IEmailJsParameterRepository emailJsParameterRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteEmailJsParameterByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteEmailJsParameterByIdCommand request, CancellationToken cancellationToken)
    {
        EmailJsParameter emailJsParameter = await emailJsParameterRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (emailJsParameter is null)
        {
            return Result<string>.Failure("Email Js parameter not found");
        }

        emailJsParameter.IsDeleted = true;

        emailJsParameterRepository.Update(emailJsParameter);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Email Js parameter delete is succesful");
    }
}
