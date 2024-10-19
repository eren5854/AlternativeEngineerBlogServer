using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.GetVisitorCount;
internal sealed class GetVisitorCountQueryHandler(
    IInformationRepository informationRepository) : IRequestHandler<GetVisitorCountQuery, Result<List<GetVisitorCountDto>>>
{
    public async Task<Result<List<GetVisitorCountDto>>> Handle(GetVisitorCountQuery request, CancellationToken cancellationToken)
    {
        var visitors = await informationRepository
            .GetAll()
            .Select(s => new GetVisitorCountDto(
                s.VisitCount))
            .ToListAsync(cancellationToken);

        return Result<List<GetVisitorCountDto>>.Succeed(visitors);
    }
}
