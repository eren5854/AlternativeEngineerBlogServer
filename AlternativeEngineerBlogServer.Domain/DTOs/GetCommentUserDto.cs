using AlternativeEngineerBlogServer.Domain.Users;

namespace AlternativeEngineerBlogServer.Domain.DTOs;
public sealed record GetCommentUserDto(
    string? UserName,
    UserRoleSmartEnum? Role);