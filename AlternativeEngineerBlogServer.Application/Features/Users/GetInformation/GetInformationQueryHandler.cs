using AlternativeEngineerBlogServer.Domain.DTOs;
using AlternativeEngineerBlogServer.Domain.Informations;
using AlternativeEngineerBlogServer.Domain.Repositories;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEngineerBlogServer.Application.Features.Users.GetInformation;
internal sealed class GetInformationQueryHandler(
    IInformationRepository informationRepository) : IRequestHandler<GetInformationQuery, Result<List<GetInformationDto>>>
{
    public async Task<Result<List<GetInformationDto>>> Handle(GetInformationQuery request, CancellationToken cancellationToken)
    {
        var informations = await informationRepository
            .GetAll()
            .Select(s => new GetInformationDto(
                s.Id,
                s.Title,
                s.SubTitle,
                s.Description,
                s.Address,
                s.PhoneNumber,
                s.LinkedinUrl,
                s.InstagramUrl,
                s.XUrl,
                s.GithubUrl))
            .ToListAsync(cancellationToken);

        return Result<List<GetInformationDto>>.Succeed(informations);
    }
}
