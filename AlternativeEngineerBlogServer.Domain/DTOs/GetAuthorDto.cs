using AlternativeEngineerBlogServer.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record GetAuthorDto(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    DateOnly? DateOfBirth,
    string? About,
    UserRoleSmartEnum Role,
    string? PhoneNumber,
    string? ProfilePicture);
