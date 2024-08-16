using AlternativeEngineerBlogServer.Domain.Users;
using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AlternativeEngineerBlogServer.Application.Features.Users.UpdateUser;
public sealed record UpdateUserCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    IFormFile? ProfilePicture,
    DateOnly? DateOfBirth,
    UserGenderEnum? Gender,
    string? PhoneNumber,
    string? About) : IRequest<Result<string>>;
