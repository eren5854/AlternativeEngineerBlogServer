using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Shared;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Links.GetLinkById;
internal sealed class GetLinkByIdCommandHandler(
    ILinkRepository linkRepository) : IRequestHandler<GetLinkByIdCommand, Result<List<Link>>>
{
    public async Task<Result<List<Link>>> Handle(GetLinkByIdCommand request, CancellationToken cancellationToken)
    {
        var linksById = await linkRepository.GetAll().Where(p => p.AppUserId == request.Id).ToListAsync(cancellationToken);

        return linksById;
    }
}
