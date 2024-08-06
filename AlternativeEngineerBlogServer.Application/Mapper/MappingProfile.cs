using AlternativeEngineerBlogServer.Application.Features.Auth.Register;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;

namespace AlternativeEngineerBlogServer.Application.Mapper;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, AppUser>();
    }
}
