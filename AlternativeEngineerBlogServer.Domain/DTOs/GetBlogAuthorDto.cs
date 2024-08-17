using AlternativeEngineerBlogServer.Domain.Users;

namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record GetBlogAuthorDto(
    string FirstName,
    string LastName,
    UserRoleSmartEnum Role,
    string? ProfilePicture);
