using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Shared;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Links.DeleteLinkById;
internal sealed class DeleteLinkByIdCommandHandler(
    ILinkRepository linkRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteLinkByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteLinkByIdCommand request, CancellationToken cancellationToken)
    {
        Link link = await linkRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (link == null)
        {
            return Result<string>.Failure("Link not found");
        }

        link.IsDeleted = true;
        linkRepository.Update(link);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link delete is successful");
    }
}
