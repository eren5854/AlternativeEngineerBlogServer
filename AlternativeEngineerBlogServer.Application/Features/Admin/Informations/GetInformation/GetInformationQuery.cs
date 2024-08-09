using AlternativeEngineerBlogServer.Domain.Informations;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.GetInformation;
public sealed record GetInformationQuery() : IRequest<Result<List<Information>>>;
