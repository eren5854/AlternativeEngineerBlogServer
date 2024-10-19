using AlternativeEngineerBlogServer.Domain.DTOs;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.Informations.GetVisitorCount;
public sealed record GetVisitorCountQuery() :IRequest<Result<List<GetVisitorCountDto>>>;
