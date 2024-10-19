using AlternativeEngineerBlogServer.Domain.EmailJsParameters;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Admin.EmailJsParameters.GetAllEmailJsParameter;
public sealed record GetAllEmailJsParameterQuery(): IRequest<Result<List<EmailJsParameter>>>;
