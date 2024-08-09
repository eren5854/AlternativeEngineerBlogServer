using AlternativeEngineerBlogServer.Domain.Informations;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.GetInformation;
internal sealed class GetInformationQueryHandler(
    IInformationRepository informationRepository) : IRequestHandler<GetInformationQuery, Result<List<Information>>>
{
    public async Task<Result<List<Information>>> Handle(GetInformationQuery request, CancellationToken cancellationToken)
    {
        var informations = await informationRepository
            .GetAll()
            .OrderBy(o => o.CreatedDate)
            .ToListAsync(cancellationToken);
        return Result<List<Information>>.Succeed(informations);
    }
}
