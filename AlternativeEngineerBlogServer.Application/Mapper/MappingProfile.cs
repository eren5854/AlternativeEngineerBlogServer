using AlternativeEngineerBlogServer.Application.Features.Admin.Categories.CreateCategory;
using AlternativeEngineerBlogServer.Application.Features.Admin.Categories.UpdateCategory;
using AlternativeEngineerBlogServer.Application.Features.Admin.SetAuthorRoleForUsers;
using AlternativeEngineerBlogServer.Application.Features.Auth.Register;
using AlternativeEngineerBlogServer.Domain.Categories;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;

namespace AlternativeEngineerBlogServer.Application.Mapper;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, AppUser>();

        CreateMap<SetAuthorRoleForUsersCommand, AppUser>();

        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
    }
}
