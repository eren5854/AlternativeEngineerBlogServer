using AlternativeEngineerBlogServer.Domain.DTOs;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.GetInformation;
public sealed record GetInformationQuery() : IRequest<Result<List<GetInformationDto>>>;
