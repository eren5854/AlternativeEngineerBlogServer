using Ardalis.SmartEnum;

namespace AlternativeEngineerBlogServer.Domain.Users;
public sealed class UserRoleSmartEnum : SmartEnum<UserRoleSmartEnum>
{
    public static readonly UserRoleSmartEnum Admin = new UserRoleSmartEnum("Admin", 1);
    public static readonly UserRoleSmartEnum Author = new UserRoleSmartEnum("Author", 2);
    public static readonly UserRoleSmartEnum  User= new UserRoleSmartEnum("User", 3);
    public UserRoleSmartEnum(string name, int value) : base(name, value)
    {
    }
}
