using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AlternativeEngineerBlogServer.Application.Features.Auth.Register;
public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password,
    //IFormFile? ProfilePicture,
    UserGenderSmartEnum? Gender): IRequest<Result<string>>;
