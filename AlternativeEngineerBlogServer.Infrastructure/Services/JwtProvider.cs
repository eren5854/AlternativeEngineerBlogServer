using AlternativeEngineerBlogServer.Application.Features.Auth.Login;
using AlternativeEngineerBlogServer.Application.Services;
using AlternativeEngineerBlogServer.Domain.Users;
using AlternativeEngineerBlogServer.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlternativeEngineerBlogServer.Infrastructure.Services;
internal class JwtProvider(
    IOptions<JwtOption> jwtOption,
    UserManager<AppUser> userManager) : IJwtProvider
{
    public async Task<LoginCommandResponse> CreateToken(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.FullName),
            //new Claim(ClaimTypes.NameIdentifier, user.Email ?? ""),
            new Claim(ClaimTypes.Email,  user.Email ?? ""),
            new Claim("UserName", user.UserName ?? ""),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        DateTime expires = DateTime.Now.AddMinutes(45);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.Value.SecretKey));

        JwtSecurityToken jwtSecurityToken = new(
            issuer: jwtOption.Value.Issuer,
            audience: jwtOption.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(jwtSecurityToken);

        string refreshToken = Guid.NewGuid().ToString();
        DateTime refreshToneExpires = expires;

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = refreshToneExpires;

        await userManager.UpdateAsync(user);

        return new(token, refreshToken, refreshToneExpires);
    }
}
