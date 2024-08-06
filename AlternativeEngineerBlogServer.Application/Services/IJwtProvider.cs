using AlternativeEngineerBlogServer.Application.Features.Auth.Login;
using AlternativeEngineerBlogServer.Domain.Users;

namespace AlternativeEngineerBlogServer.Application.Services;
public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}