﻿using AlternativeEngineerBlogServer.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace AlternativeEngineerBlogServer.Domain.Users;
public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public string? ProfilePicture {  get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? About {  get; set; }

    public List<Link> Links { get; set; } = new List<Link>();
    
    //public Guid? LinkId { get; set; }
    //public Link? Link { get; set; }
    
    //public UserGenderSmartEnum? Gender { get; set; }
    public UserGenderEnum Gender { get; set; } = UserGenderEnum.Belirtilmemiş;
    public UserRoleSmartEnum Role { get; set; } = UserRoleSmartEnum.User;

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }

    public int? ForgotPasswordCode { get; set; }
    public DateTime? ForgotPasswordCodeSendDate { get; set; }

    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
